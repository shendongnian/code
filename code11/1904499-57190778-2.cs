    static void Main(string[] args)
    {
        Document document = new Document();
        const string file = "file";
        const string txtFileContents = "1|1.0";
        const string pdfFile = "myPdfFile.pdf";
        try
        {
            string[] array = txtFileContents.Split('|');
            FileStream fs = new FileStream(pdfFile, FileMode.Open);
            document.Number = array[0];
            document.Revision = array[1];
            document.FileName = file;
            document.File = fs;
        }
        catch (Exception exception)
        {
        }
        // Serialize the Document object
        // File, in the JSON contents, will be a Base64 encoded string
        var serializedContents = JsonConvert.SerializeObject(document);
        // Deserialize the contents
        // File will be a Stream
        var deserializedContents = JsonConvert.DeserializeObject<Document>(serializedContents);
        // For demo purposes, this will write the Document.File object back to a new PDF file for comparison
        using (var fileStream = File.Create("myDeserializedPdfFile.pdf"))
        {
            var fileAsMemoryStream = (MemoryStream)deserializedContents.File;
            fileAsMemoryStream.WriteTo(fileStream);
        }
    }
