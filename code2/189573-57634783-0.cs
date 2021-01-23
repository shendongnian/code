       public ActionResult Download()
            {
                var document = //Obtain document from database context
        var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = document.FileName,
            Inline = false,
        };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(document.Data, document.ContentType);
            }
