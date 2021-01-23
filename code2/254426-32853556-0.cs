                public string GetResponse()
                {
                    // Get the original response.
                    var response = _request.GetResponse();
                    Status = ((HttpWebResponse) response).StatusDescription;
                    // Get the stream containing all content returned by the requested server.
                    _dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    var reader = new StreamReader(_dataStream);
                    // Read the content fully up to the end.
                    var responseFromServer = reader.ReadToEnd();
                    // Clean up the streams.
                    reader.Close();
                    if (_dataStream != null) 
                        _dataStream.Close();
                    response.Close();
                    return responseFromServer;
                }
                /// <summary>
                /// Custom timeout on responses
                /// </summary>
                /// <param name="millisec"></param>
                /// <returns></returns>
                public string GetResponse(int millisec)
                {
                    //Spin off a new thread that's safe for an ASP.NET application pool.
                    var responseFromServer = "";
                    var resetEvent = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(arg =>
                        {
                            try
                            {
                                responseFromServer = GetResponse();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                resetEvent.Set();//end of thread
                            }
                        });
                    //handle a timeout with a asp.net thread safe method 
                    WaitHandle.WaitAll(new WaitHandle[] { resetEvent }, millisec);
                    return responseFromServer;
                }
