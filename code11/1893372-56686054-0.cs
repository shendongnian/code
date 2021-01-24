    [HttpPost]
    public async Task<IActionResult> SendEmailAsync(string emailModel, List<IFormFile> files)
    {
        EmailModel emailModel = JsonConvert.DeserializeObject<EmailModelWith>(emailModel);
        List<Attachment> attachments = new List<Attachment>();
        foreach (var file in files)
        {
             Attachment attachment = new Attachment(file.OpenReadStream(), file.FileName, file.ContentType);
             attachments.Add(attachment);
        }
        return Ok();
    }
