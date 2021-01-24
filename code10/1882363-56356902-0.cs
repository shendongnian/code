public FileResult Download(string documentID) {
            string fileName = @"C:\\Temp\\temp\\" + documentID + ".hex";
            FileInfo fileInfo = new FileInfo(fileName);
            
            if (fileInfo.Exists) {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
            return File(fileName, "application/octet-stream");
        }
