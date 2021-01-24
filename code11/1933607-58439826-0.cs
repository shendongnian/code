    [HttpGet]
    public HttpResponseMessage Get(string id)
    {
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        String[] strArray = id.Split(',');
        var ms = new MemoryStream();
        for (int i = 0; i < strArray.Length; i++)
        {
            String filePath = HostingEnvironment.MapPath("~/Fotos/Empresas/Comer/" + strArray[i] + (i + 1) + ".jpg");
            byte[] bytes = File.ReadAllBytes(filePath);
            byte[] length = BitConverter.GetBytes(bytes.Length);
            // Write length followed by file bytes to stream
            ms.Write(length, 0, 4);
            ms.Write(bytes, 0, bytes.Length);
        }
        result.Content = new StreamContent(ms);
        return result;
    }
