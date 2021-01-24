    public async Task<IActionResult> Documentation(DocUpload document)
    {
        if (document.Document != null)
        {
            // do other validations on your model as needed
            try
            {
                string fileName = "Interface-" + document.InterfaceId + "-Documentation" +
                                        Path.GetExtension(document.Document.FileName);
                string doucumentationPath = Path.Combine(_hostingEnvironment.WebRootPath, "documentation");
                string filePath = Path.Combine(doucumentationPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await document.Document.CopyToAsync(stream);
                }
                string fileUrl = "~/documentation/" + fileName;
            }
            catch (Exception e)
            {
                document.Error = true;
                document.Message = "The has been a problem uploading the documentation:" + Environment.NewLine +
                                    e.Message;
            }
            //to do save to db  
        }
        return View(document);
    }
