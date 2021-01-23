    private static void AppendToDocument(string sourcePdfPath)
    {
        var tempFileLocation = Path.GetTempFileName();
        var bytes = File.ReadAllBytes(sourcePdfPath);
        using (var reader = new PdfReader(bytes))
        {
            var numberofPages = reader.NumberOfPages;
            var modPages = (numberofPages % 4);
            var pages = modPages == 0 ? 0 : 4 - modPages;
            if (pages == 0)
                return;
            using (var fileStream = new FileStream(tempFileLocation, FileMode.Create, FileAccess.Write))
            {
                using (var stamper = new PdfStamper(reader, fileStream))
                {
                    var rectangle = reader.GetPageSize(1);
                    for (var i = 1; i <= pages; i++)
                        stamper.InsertPage(numberofPages + i, rectangle);
                }
            }
        }
        File.Delete(sourcePdfPath);
        File.Move(tempFileLocation, sourcePdfPath);
    }
