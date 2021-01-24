      public async Task<IActionResult> Download(string filename)  
      {  
          if (filename == null)  
              return Content("filename not present");  
      
          var path = Path.Combine(  
                         Directory.GetCurrentDirectory(),  
                         "wwwroot", filename);  
      
          var memory = new MemoryStream();  
          using (var stream = new FileStream(path, FileMode.Open))  
          {  
              await stream.CopyToAsync(memory);  
          }  
          memory.Position = 0;  
          return File(memory, GetContentType(path), Path.GetFileName(path));  
      } 
