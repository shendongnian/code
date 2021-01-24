     public IActionResult DownloadFile(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = "myfile.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
           //For preview pdf and the download it use below code
           // var stream = new FileStream(filePath, FileMode.Open);
           //return new FileStreamResult(stream, "application/pdf");
        }
