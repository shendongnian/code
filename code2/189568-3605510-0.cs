    public FileResult Download()
    {
        byte[] fileBytes = ...;
        string fileName = "example";
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
