        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="headers"></param>
        [WebMethod(EnableSession=true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static bool exportToCSV(List<object> elements, List<string> headers)
        {
            try
            {
                string attachmentType = "attachment; filename=Shortage Report.csv";
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                
                HttpContext.Current.Response.AddHeader("Content-Disposition", attachmentType);
                HttpContext.Current.Response.ContentType = "text/csv";
                writeHeadersInfo(headers);
                writeBodyInfo(headers, elements);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
