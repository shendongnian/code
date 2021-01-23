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
