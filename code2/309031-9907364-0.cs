        public static void WriteCSVToResponse(string csv, string filename)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.ContentType = "text/csv";
            response.AddHeader("content-disposition", "attachment; filename=" + filename);
            response.ContentEncoding = Encoding.UTF8;
            byte[] BOM = new byte[] { 0xef, 0xbb, 0xbf };
            response.BinaryWrite(BOM);//write the BOM first
            response.BinaryWrite(Encoding.UTF8.GetBytes(csv));
            response.Flush();
            response.End();
        }
