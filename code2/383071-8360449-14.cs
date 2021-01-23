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
        /// <summary>
        /// This method streams a file to a user
        /// </summary>
        /// <param name="cMimeTypes">The set of known mimetypes. This is only needed when the file is not being downloaded.</param>
        /// <param name="sFileName"></param>
        /// <param name="sFileNameForUser"></param>
        /// <param name="theResponse"></param>
        /// <param name="fDownload"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool StreamFileToUser(System.Collections.Generic.Dictionary<string, string> cMimeTypes, string sFileName, string sFileNameForUser, HttpResponse theResponse, bool fDownload = true, bool fOkToDeleteFile = false)
        {
            // Exceptions are handled by the caller
            bool fDontEndResponse = false;
            sFileNameForUser = CleanFileName(sFileNameForUser);
            // Ensure there is nothing else in the response
            try
            {
                try
                {
                    // Remove what other controls may have been put on the page
                    theResponse.ClearContent();
                    // Clear any headers
                    theResponse.ClearHeaders();
                }
                catch (System.Web.HttpException theException)
                {
                    // Ignore this exception, which could occur if there were no HTTP headers in the response
                }
                bool fFoundIt = false;
                if (!fDownload)
                {
                    string sExtension = null;
                    sExtension = System.IO.Path.GetExtension(sFileNameForUser);
                    if (!(string.IsNullOrEmpty(sExtension)))
                    {
                        sExtension = sExtension.Replace(".", "");
                        if (cMimeTypes.ContainsKey(sExtension))
                        {
                            theResponse.ContentType = cMimeTypes[sExtension];
                            theResponse.AddHeader("Content-Disposition", "inline; filename=" + sFileNameForUser);
                            fFoundIt = true;
                        }
                    }
                }
                if (!fFoundIt)
                {
                    theResponse.ContentType = "application/octet-stream";
                    theResponse.AddHeader("Content-Disposition", "attachment; filename=" + sFileNameForUser);
                }
                theResponse.TransmitFile(sFileName);
                // Ensure the file is properly flushed to the user
                theResponse.Flush();
            }
            finally
            {
                // If the caller wants, delete the file before the response is terminated
                if (fOkToDeleteFile)
                {
                    System.IO.File.Delete(sFileName);
                }
            }
            // Ensure the response is closed
            theResponse.Close();
            if (!fDontEndResponse)
            {
                try
                {
                    theResponse.End();
                }
                catch
                {
                }
            }
            return true;
        }
        /// <summary>
        /// This method generates a standard list of extension to content-disposition tags
        /// The key for each item is the file extension without the leading period. The value 
        /// is the content-disposition.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Collections.Generic.Dictionary<string, string> GenerateStandardMimeList()
        {
            // Exceptions are handled by the caller.
            System.Collections.Generic.Dictionary<string, string> cItems = new Dictionary<string, string>();
            cItems.Add("jpeg", "image/jpeg");
            cItems.Add("jpg", "image/jpeg");
            cItems.Add("pdf", "application/pdf");
            cItems.Add("csv", "application/vnd.ms-excel");
            cItems.Add("doc", "application/msword");
            cItems.Add("docx", "application/vnd.ms-word.document.12");
            cItems.Add("xls", "application/vnd.ms-excel");
            cItems.Add("xlsx", "application/vnd.ms-excel.12");
            
            return cItems;
        }
        /// <summary>
        /// This method removes all invalid characters from the specified file name.
        /// Note that ONLY the file name should be passed, not the directory name.
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string CleanFileName(string sFileName)
        {
            // Exceptions are handled by the caller
            // If there are any invalid characters in the file name
            if (sFileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                // Strip them out (split to remove the characters, then rejoin the pieces into one string)
                return string.Join("", sFileName.Split(System.IO.Path.GetInvalidFileNameChars()));
            }
            else
            {
                return sFileName;
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
