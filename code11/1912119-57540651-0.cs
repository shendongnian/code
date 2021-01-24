    public static MemoryStream GetWordDocumentStreamFromTemplate()
    {
        var templatePath = AppDomain.CurrentDomain.BaseDirectory + "Controllers\\" + templateFileName;
        var memoryStream = new MemoryStream();
        using (var fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            fileStream.CopyTo(memoryStream);
        using (var document = WordprocessingDocument.Open(memoryStream, true))
        {
            document.ChangeDocumentType(WordprocessingDocumentType.Document); // change from template to document
            var body = document.MainDocumentPart.Document.Body;
            //add some text 
            Paragraph paraHeader = body.AppendChild(new Paragraph());
            Run run = paraHeader.AppendChild(new Run());
            run.AppendChild(new Text("This is body text"));
            document.Close();
        }
        memoryStream.Position = 0; //let's rewind it
        return memoryStream;
    }
