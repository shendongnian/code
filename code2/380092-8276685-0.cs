    window.location.href='FileDownloader.ashx?FileName=ErrorLog.txt'
    
    public class FileDownloader: IHttpHandler
    {
           public bool IsReusable
           {
                get { return true; }
           }
    
           public void ProcessRequest(HttpContext context)
           {
                // This is where you read the log file and add the content disposition
                //header
                string strPath = Server.MapPath("ErrorLog") + "\\" + context.Request.QueryString["FileName"];
                
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + context.Request.QueryString["FileName"] + "");
                strPath.Length.ToString());
                context.Response.ContentType = "application/text";
                context.Response.WriteFile(strPath);
                context.Response.End();
           }
    }
    
