            public ActionResult Download() 
        {
            Document document = new Document();
            document.Info.Title = "Hello";
            Section section = document.AddSection();
            section.AddParagraph("Hello").AddFormattedText("World", TextFormat.Bold);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = document;
            renderer.RenderDocument();
            return new PdfResult(renderer.PdfDocument);
        }
