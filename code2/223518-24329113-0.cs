    {
            // buffer to read stream
            byte[] buffer = new byte[bufSize];
            // JPEG magic number
            byte[] jpegMagic = new byte[] { 0xFF, 0xD8, 0xFF };
            int jpegMagicLength = 3;
            ASCIIEncoding encoding = new ASCIIEncoding();
            while (!stopEvent.WaitOne(0, false))
            {
                // reset reload event
                reloadEvent.Reset();
                // HTTP web request
                HttpWebRequest request = null;
                // web responce
                WebResponse response = null;
                // stream for MJPEG downloading
                Stream stream = null;
                // boundary betweeen images (string and binary versions)
                byte[] boundary = null;
                string boudaryStr = null;
                // length of boundary
                int boundaryLen;
                // flag signaling if boundary was checked or not
                bool boundaryIsChecked = false;
                // read amounts and positions
                int read, todo = 0, total = 0, pos = 0, align = 1;
                int start = 0, stop = 0;
                // align
                //  1 = searching for image start
                //  2 = searching for image end
                try
                {
                    // create request
                    request = (HttpWebRequest)WebRequest.Create(m_Source);
                    // set user agent
                    if (userAgent != null)
                    {
                        request.UserAgent = userAgent;
                    }
                    // set proxy
                    if (proxy != null)
                    {
                        request.Proxy = proxy;
                    }
                    // set timeout value for the request
                    request.Timeout = requestTimeout;
                    // set login and password
                    if ((login != null) && (password != null) && (login != string.Empty))
                        request.Credentials = new NetworkCredential(login, password);
                    // set connection group name
                    if (useSeparateConnectionGroup)
                        request.ConnectionGroupName = GetHashCode().ToString();
                    // force basic authentication through extra headers if required
                    if (forceBasicAuthentication)
                    {
                        string authInfo = string.Format("{0}:{1}", login, password);
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        request.Headers["Authorization"] = "Basic " + authInfo;
                    }
                    // get response
                    response = request.GetResponse();
                    // check content type
                    string contentType = response.ContentType;
                    string[] contentTypeArray = contentType.Split('/');
                    // "application/octet-stream"
                    if ((contentTypeArray[0] == "application") && (contentTypeArray[1] == "octet-stream"))
                    {
                        boundaryLen = 0;
                        boundary = new byte[0];
                    }
                    else if ((contentTypeArray[0] == "multipart") && (contentType.Contains("mixed")))
                    {
                        // get boundary
                        int boundaryIndex = contentType.IndexOf("boundary", 0);
                        if (boundaryIndex != -1)
                        {
                            boundaryIndex = contentType.IndexOf("=", boundaryIndex + 8);
                        }
                        if (boundaryIndex == -1)
                        {
                            // try same scenario as with octet-stream, i.e. without boundaries
                            boundaryLen = 0;
                            boundary = new byte[0];
                        }
                        else
                        {
                            boudaryStr = contentType.Substring(boundaryIndex + 1);
                            // remove spaces and double quotes, which may be added by some IP cameras
                            boudaryStr = boudaryStr.Trim(' ', '"');
                            boundary = encoding.GetBytes(boudaryStr);
                            boundaryLen = boundary.Length;
                            boundaryIsChecked = false;
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid content type.");
                    }
                    // get response stream
                    stream = response.GetResponseStream();
                    stream.ReadTimeout = requestTimeout;
                    // loop
                    while ((!stopEvent.WaitOne(0, false)) && (!reloadEvent.WaitOne(0, false)))
                    {
                        // check total read
                        if (total > bufSize - readSize)
                        {
                            total = pos = todo = 0;
                        }
                        // read next portion from stream
                        if ((read = stream.Read(buffer, total, readSize)) == 0)
                            throw new ApplicationException();
                        total += read;
                        todo += read;
                        // increment received bytes counter
                        bytesReceived += read;
                        // do we need to check boundary ?
                        if ((boundaryLen != 0) && (!boundaryIsChecked))
                        {
                            // some IP cameras, like AirLink, claim that boundary is "myboundary",
                            // when it is really "--myboundary". this needs to be corrected.
                            pos = Utility.ContainsBytes(buffer, ref start, ref read, boundary, 0, boundary.Length);
                            // continue reading if boudary was not found
                            if (pos == -1)
                                continue;
                            for (int i = pos - 1; i >= 0; i--)
                            {
                                byte ch = buffer[i];
                                if ((ch == (byte)'\n') || (ch == (byte)'\r'))
                                {
                                    break;
                                }
                                boudaryStr = (char)ch + boudaryStr;
                            }
                            boundary = encoding.GetBytes(boudaryStr);
                            boundaryLen = boundary.Length;
                            boundaryIsChecked = true;
                        }
                        // search for image start
                        if ((align == 1) && (todo >= jpegMagicLength))
                        {
                            start = Utility.ContainsBytes(buffer, ref pos, ref todo, jpegMagic, 0, jpegMagicLength);
                            if (start != -1)
                            {
                                // found JPEG start
                                pos = start + jpegMagicLength;
                                todo = total - pos;
                                align = 2;
                            }
                            else
                            {
                                // delimiter not found
                                todo = jpegMagicLength - 1;
                                pos = total - todo;
                            }
                        }
                        // search for image end ( boundaryLen can be 0, so need extra check )
                        while ((align == 2) && (todo != 0) && (todo >= boundaryLen))
                        {
                            stop = Utility.ContainsBytes(buffer, ref start, ref read,
                                (boundaryLen != 0) ? boundary : jpegMagic,
                                pos, todo);
                            if (stop != -1)
                            {
                                pos = stop;
                                todo = total - pos;
                                // increment frames counter
                                framesReceived++;
                                // image at stop
                                using (Bitmap bitmap = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, start, stop - start)))
                                {
                                    // notify client
                                    Packetize(bitmap);
                                }
                                // shift array
                                pos = stop + boundaryLen;
                                todo = total - pos;
                                Array.Copy(buffer, pos, buffer, 0, todo);
                                total = todo;
                                pos = 0;
                                align = 1;
                            }
                            else
                            {
                                // boundary not found
                                if (boundaryLen != 0)
                                {
                                    todo = boundaryLen - 1;
                                    pos = total - todo;
                                }
                                else
                                {
                                    todo = 0;
                                    pos = total;
                                }
                            }
                        }
                    }
                }
                catch (ApplicationException)
                {
                    // do nothing for Application Exception, which we raised on our own
                    // wait for a while before the next try
                    Thread.Sleep(250);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch (Exception exception)
                {
                    // wait for a while before the next try
                    Thread.Sleep(250);
                }
                finally
                {
                    // abort request
                    if (request != null)
                    {
                        request.Abort();
                        request = null;
                    }
                    // close response stream
                    if (stream != null)
                    {
                        stream.Close();
                        stream = null;
                    }
                    // close response
                    if (response != null)
                    {
                        response.Close();
                        response = null;
                    }
                }
                // need to stop ?
                if (stopEvent.WaitOne(0, false))
                    break;
            }
        }
    }
