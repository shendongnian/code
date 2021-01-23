    using System.Web;
    namespace Modules.Log
    {
        using System;
        using System.Text;
        public class LogModule : IHttpModule
        {
            private bool initialized = false;
            private object initLock = new Object();
            private static string applicationName = string.Format("Server: {0}; [LogModule_AppName] installation name is not set", System.Environment.MachineName);
            public void Dispose()
            {
            }
            public void Init(HttpApplication context)
            {
                // Do this one time for each AppDomain.
                if (!initialized)
                {
                    lock (initLock)
                    {
                        if (!initialized)
                        {
                            context.Error += new EventHandler(this.OnUnhandledApplicationException);
                            initialized = true;
                        }
                    }
                }
            }
            private void OnUnhandledApplicationException(object sender, EventArgs e)
            {
                StringBuilder message = new StringBuilder("<html><head><style>" +
                    "body, table { font-size: 12px; font-family: Arial, sans-serif; }\r\n" +
                    "table tr td { padding: 4px; }\r\n" +
                    ".header { font-weight: 900; font-size: 14px; color: #fff; background-color: #2b4e74; }\r\n" +
                    ".header2 { font-weight: 900; background-color: #c0c0c0; }\r\n" +
                    "</style></head><body><table><tr><td class=\"header\">\r\n\r\nUnhandled Exception logged by LogModule.dll:\r\n\r\nappId=");
                string appId = (string)AppDomain.CurrentDomain.GetData(".appId");
                if (appId != null)
                {
                    message.Append(appId);
                }
                message.Append("</td></tr>");
                HttpServerUtility server = HttpContext.Current.Server;
                Exception currentException = server.GetLastError();
                if (currentException != null)
                {
                    message.AppendFormat(
                            "<tr><td class=\"header2\">TYPE</td></tr><tr><td>{0}</td></tr><tr><td class=\"header2\">REQUEST</td></tr><tr><td>{3}</td></tr><tr><td class=\"header2\">MESSAGE</td></tr><tr><td>{1}</td></tr><tr><td class=\"header2\">STACK TRACE</td></tr><tr><td>{2}</td></tr>",
                            currentException.GetType().FullName,
                            currentException.Message,
                            currentException.StackTrace,
                            HttpContext.Current != null ? HttpContext.Current.Request.FilePath : "n/a");
                    server.ClearError();
                }
                message.Append("</table></body></html>");
                HttpContext.Current.Response.Write(message.ToString());
                server.ClearError();
            }
        }
    }
