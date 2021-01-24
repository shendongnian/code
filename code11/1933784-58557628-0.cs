    using System;
    using System.Text;
    using System.IO;
    
    namespace BF
    {
    	//This is a custom publisher class use to publish the exception details 
    	//into log file
    	public class LogPublisher 
    	{
            private static object _lock;
    
            static LogPublisher()
            {
                _lock = new object();
            }
    
    		//Constructor
            public LogPublisher()
    		{
    		}
    
            //Method to publish the exception details into log file
            public static void Debug(string message)
            {
                if (ClientConfigHandler.Config.IsDebugMode())
                {
                    Exception eMsg = new Exception(message);
    
                    Publish(eMsg, "#DEBUG");
                }
            }
    
            public static void DebugBackgroundAction(string message)
            {
                if (ClientConfigHandler.Config.IsDebugMode())
                {
                    Exception eMsg = new Exception(message);
    
                    Publish(eMsg, "#DEBUG #BG");
                }
            }
    
            public static void BackgroundAction(string message)
            {
                Exception eMsg = new Exception(message);
    
                Publish(eMsg, "#BG");
            }
    
            public static void Publish(string message)
            {
                Exception eMsg = new Exception(message);
    
                Publish(eMsg, "");
            }
    
            public static void Publish(Exception fException)
            {
                Publish(fException, "");
            }
    
    
            public static void Publish(Exception fException, string prefix)
    		{
                if (fException == null) return;
    
    			// Load Config values if they are provided.
                string m_LogName = ResourceConfig.LogFileName;
    
    			// Create StringBuilder to maintain publishing information.
    			StringBuilder strInfo = new StringBuilder();
    
    			// Record required content of the AdditionalInfo collection.
                strInfo.AppendFormat("{0}**T {1} {2} ", Environment.NewLine, CommonConversions.CurrentTime.ToString(CommonConversions.DATE_TIME_FORMAT_LOG), prefix);
                
    			// Append the exception message and stack trace
                strInfo.Append(BuildExceptionLog(fException, false));
    
                try
                {
                    lock (_lock)
                    {
                        FileStream fs = File.Open(m_LogName, FileMode.Append, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(strInfo.ToString());
                        sw.Close();
                        fs.Close();
                    }
                }
                catch
                {
                    //ignore log error
                }
            }
    
            private static string BuildExceptionLog(Exception fException, bool isInnerExp)
            {
                StringBuilder strInfo = new StringBuilder();
    
                if (fException != null)
                {
                    string msgType;
    
                    if (isInnerExp)
                    {
                        msgType = "#IN-ERR";
                    }
                    else if (fException.StackTrace == null)
                    {
                        msgType = "#INF";
                    }
                    else
                    {
                        msgType = "#ERR";
                    }
    
                    strInfo.AppendFormat("{0}: {1}", msgType, fException.Message.ToString());
    
                    if (fException.StackTrace != null)
                    {
                        strInfo.AppendFormat("{0}#TRACE: {1}", Environment.NewLine, fException.StackTrace);
                    }
    
                    if (fException.InnerException != null)
                    {
                        strInfo.AppendFormat("{0}{1}", Environment.NewLine, BuildExceptionLog(fException.InnerException, true));
                    }
                }
    
                return strInfo.ToString();
            }
    	}
    }
