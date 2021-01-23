    public class DownloadRequestHandler : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    
        /// <summary>
        /// This method is used to process the incoming request
        /// </summary>
        /// <param name="oContext"></param>
        /// <remarks></remarks>
        public void ProcessRequest(HttpContext oContext)
        {
            try
            {
                string sFileName = null;
                string sSourceFilePath = null;
    
                // Should add existence checking here
                sFileName = oContext.Request.QueryString["FileName"];
    
                // Assume that the files are stored in the relative directory Files. Should add existence checking here
                sSourceFilePath = System.IO.Path.Combine(oContext.Server.MapPath("Files"), sFileName);
    
                StreamFileToUser(GenerateStandardMimeList(), sSourceFilePath, sFileName, oContext.Response, false, false);
            }
            catch (System.Threading.ThreadAbortException theException)
            {
                // Do nothing
            }
            catch (Exception theException)
            {
                SendErrorToUser(oContext.Response, theException.Message);
            }
        }
        public void SendErrorToUser(HttpResponse theResponse, string sError)
        {
            // Note that errors are handled by the caller
    
            sError = "<script>alert(\"" + sError.Replace("\"", "").Replace(Environment.NewLine, "\\n") + "\");</script>";
            // Ensure there is nothing else in the response
            theResponse.Clear();
            theResponse.Write(sError);
            theResponse.Flush();
        }
    }
