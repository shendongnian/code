    public FileResult SaveFile(string LicenseFileJson)
    {
       License License = (License)JsonConvert.DeserializeObject(LicenseFileJson);
       LicenseTool tool = new LicenseTool(License);
       string licenseFileString = tool.ToFileString();
       //byte[] bytes = Encoding.ASCII.GetBytes(licenseFileString);
       //var stream = new MemoryStream();
       //var writer = new StreamWriter(stream);
       //writer.Write(licenseFileString);
       //writer.Flush();            
       //Response.Headers.Add("Content-Disposition", "attachment;");
       return File(System.Text.Encoding.UTF8.GetBytes(licenseFileString), "text/xml", "testing123.xml");
    }
