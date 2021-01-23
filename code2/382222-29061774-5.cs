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
                    //Cont. your code of log file
