      public ActionResult DownloadFile(string fileWithFullPath)
        {                
            var fileBytes = System.IO.File.ReadAllBytes(fileWithFullPath);    
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
        }
