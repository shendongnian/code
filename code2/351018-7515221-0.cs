    void WriteToXls(string fromfilePath, string targetFileName)
        {
            if (!String.IsNullOrEmpty(fromfilePath)) 
            {
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Charset = "utf-8";
                response.ContentType = "text/xls";
                response.AddHeader("content-disposition", string.Format("attachment; filename={0}", targetFileName));
                response.BinaryWrite(File.ReadAllBytes(fromfilePath));
                response.End();
            }
        }
