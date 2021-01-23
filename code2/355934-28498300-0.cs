                while (true)
                {
                    string s = null;
                    DateTime readLag = DateTime.Now;
                    try
                    {
                        s = streamIn.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        SocketException sockEx = ex.InnerException as SocketException;
                        if (sockEx != null)
                        {
                            OnDebug("(" + sockEx.NativeErrorCode + ") Exception = " + ex);
                        }
                        else
                        {
                            OnDebug("Not SockEx :" + ex);
                        }
                    }
                    if (enableLog) OnDebug(s);
                    if (s == null || s == "")
                    {
                        if (readLag.AddSeconds(.9) > DateTime.Now)
                        {
                            break;
                        }
                    }
                    else
                    {
                        CommandParser(s);
                    }
                }
