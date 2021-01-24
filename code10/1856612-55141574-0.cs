    [HttpPost]
    public async Task<IActionResult> Create([FromForm]AttachmentViewModel attachment, [FromForm]IFormFile[] Files)
    {
        //initialize attachmentFiles 
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(attachment.Id.ToString()), "Id");
        content.Add(new StringContent(attachment.Type), "Type");
        content.Add(new StringContent(attachment.TypeID.ToString()), "TypeID");
        content.Add(new StringContent(attachment.FileDesc), "FileDesc");
        for (int i = 0; i < attachment.AttachmentFiles.Count; i++)
        {
            var attachmentFile = attachment.AttachmentFiles[i];
            content.Add(new StreamContent(attachmentFile.Files.OpenReadStream()), $"AttachmentFiles[{i}].Files", attachmentFile.Files.FileName);
            content.Add(new StringContent(attachmentFile.FileExt), $"AttachmentFiles[{i}].FileExt");
            content.Add(new StringContent(attachmentFile.FileName), $"AttachmentFiles[{i}].FileName");
            content.Add(new StringContent(attachmentFile.Id.ToString()), $"AttachmentFiles[{i}].Id");
        }
        HttpResponseMessage res = await httpClient.PostAsync("api/nofactory/createattachment", content);
        List<AttachmentViewModel> model = new List<AttachmentViewModel>();
        model.Add(attachment);
        return View("index", model);
    }
