            Microsoft.AspNetCore.Http.IFormCollection form;
            form = ControllerContext.HttpContext.Request.Form; 
            using (var fileStream = System.IO.File.Create(strFile))
            {
                form.Files[0].OpenReadStream().Seek(0, System.IO.SeekOrigin.Begin);
                form.Files[0].OpenReadStream().CopyTo(fileStream);
            }
