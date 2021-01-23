            public static void DownloadFile(HttpResponse response,string fileRelativePath)
        {
            try
            {
                string contentType = "";
                //Get the physical path to the file.
                string FilePath = HttpContext.Current.Server.MapPath(fileRelativePath);
                string fileExt = Path.GetExtension(fileRelativePath).Split('.')[1].ToLower();
                if (fileExt == "pdf")
                {
                    //Set the appropriate ContentType.
                    contentType = "Application/pdf";
                }
                //Set the appropriate ContentType.
                response.ContentType = contentType;
                response.AppendHeader("content-disposition", "attachment; filename=" + (new FileInfo(fileRelativePath)).Name);
                //Write the file directly to the HTTP content output stream.
                response.WriteFile(FilePath);
                response.End();
            }
            catch
            {
               //To Do
            }
        }
