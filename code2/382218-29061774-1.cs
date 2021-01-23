     string _exMsgErr = string.Empty;
                    var frame = oStackTrace.FrameCount > 1 ? oStackTrace.GetFrame(1) : oStackTrace.GetFrame(0);
                    if (oException.GetType() == typeof(JOVALException))
                    {
                        JOVALException _JOVALEx = (JOVALException)oException;
                        _exMsgErr = _JOVALEx.Message;
                    }
                    else
                    {
                        _exMsgErr = oException.Message;
                    }
                    ErrorLog oError = new ErrorLog(frame.GetMethod().Name, (string)frame.GetFileName(), (int)frame.GetFileLineNumber(), sCustomErrorMessage == string.Empty ? _exMsgErr : sCustomErrorMessage, sUserID, oErrCode);
                    List<ErrorLog> lstErrorsLog = new List<ErrorLog>();
                    XmlSerializer _xmlSerialize = new XmlSerializer(typeof(List<ErrorLog>));
                    if (File.Exists(LogFilePath))
                    {
                        using (StreamReader _reader = new StreamReader(LogFilePath))
                        {
                            if (!_reader.EndOfStream)
                            {
                                lstErrorsLog = (List<ErrorLog>)_xmlSerialize.Deserialize(_reader);
                                _reader.Close();
                            }
                        }
                    }
                    else
                    {
                        var _file = File.Create(LogFilePath);
                        _file.Close();
    
                    }
                    lstErrorsLog.Insert(0, oError);
                    using (StreamWriter _txtWrt = new StreamWriter(LogFilePath))
                    {
                        _xmlSerialize.Serialize(_txtWrt, lstErrorsLog);
                        _txtWrt.Close();
                    }
                }
                catch (IOException ex)
                {
                    //
                }
                catch (Exception ex)
                {
                   //
                }
