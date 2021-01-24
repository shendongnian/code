string sDownloadFile = Session["strImagePath"].ToString();
            string sFileName = Session["sFileName"].ToString();// Original file name// System.IO.Path.GetFileName(sDownloadFile);
            byte[] fileBytes = System.IO.File.ReadAllBytes(sDownloadFile);
            SendFileBytesToResponse(fileBytes, sFileName);
private static void SendFileBytesToResponse(byte[] bytes, string sFileName)
        {
            if (bytes != null)
            {
                string downloadName = sFileName;
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.AddHeader("Content-Type", "application/jpeg");
                response.AddHeader("Content-Disposition",
                                   "attachment; filename=" + downloadName + "; size=" + bytes.Length.ToString());
                response.Flush();
                response.BinaryWrite(bytes);
                response.Flush();
                response.End();
            }           
        }
