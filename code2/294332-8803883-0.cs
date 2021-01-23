    private void PrintMenu()
    {
        ...
        var notUriPath = Server.MapPath("~/" + filePathName);
        var doc = new Document();
        var reader = new PdfReader(notUriPath);
        using (var memoryStream = new MemoryStream())
        {
            var writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();
            // this action leads directly to printer dialogue
            var jAction = PdfAction.JavaScript("this.print(true);\r", writer);
            writer.AddJavaScript(jAction);
            var cb = writer.DirectContent;
            doc.AddDocListener(writer);
            for (var p = 1; p <= reader.NumberOfPages; p++)
            {
                doc.SetPageSize(reader.GetPageSize(p));
                doc.NewPage();
                var page = writer.GetImportedPage(reader, p);
                var rot = reader.GetPageRotation(p);
                if (rot == 90 || rot == 270)
                    cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(p).Height);
                else
                    cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
            }
            reader.Close();
            doc.Close();
            File.WriteAllBytes(notUriPath, memoryStream.ToArray());
        }
        theIframeForPrint.Attributes.Add("src", fullFilePath);
    }
