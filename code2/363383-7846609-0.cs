    public ActionResult Display(int id)
    {
        Document doc = GetDocById(id);
        byte[] byteArray = doc.Content;//its has the image in bytes
        return new FileStreamResult(new System.IO.MemoryStream(byteArray), "image/jpeg");
    }
