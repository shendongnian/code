    public async Task<ActionResult> Download(...) {
    
        var data = await someService.GetZipFile();
        String filename = data.FileName;
        String content = data.Content;
        //convert from base64 string
        byte[] bytes = Convert.FromBase64String(content);
        
        return File(bytes, "application/zip", filename);
    }
