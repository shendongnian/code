    public async Task<ActionResult> Download(...) {
    
        var data = await someService.GetZipFile();
        String filename = data.FileName;
        String content = data.Content;
        byte[] bytes = Encoding.ASCII.GetBytes(content);
        
        return File(bytes, "application/zip", filename);
    }
