    Public Action File(string filename)
    {
      if(user is authorize)
      { 
          Search file on server
          if(File Is present) 
          { 
            var file = "filename.pdf";
            // Response...
            System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
            {
              FileName = file,
              Inline = true 
                  // false = prompt the user for downloading;  
                  // true = browser to try to show the file inline
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return File(System.IO.File.ReadAllBytes(file), "application/pdf");         
          }
       } 
    }
