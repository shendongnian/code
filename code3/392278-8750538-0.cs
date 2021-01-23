            StringBuilder xhtmlBuilder = new StringBuilder();
            xhtmlBuilder.Append("<html>");
            xhtmlBuilder.Append("<body>");
            xhtmlBuilder.Append("<b>Hello world!</b>");
            xhtmlBuilder.Append("</body>");
            xhtmlBuilder.Append("</html>");
            using (WordprocessingDocument doc = WordprocessingDocument.Open(inputFilePath, true))
            {
                string altChunkId = "chunk1";
                AlternativeFormatImportPart chunk = doc.MainDocumentPart.AddAlternativeFormatImportPart
                    (AlternativeFormatImportPartType.Xhtml, altChunkId);
                using (MemoryStream xhtmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xhtmlBuilder.ToString())))
                {
                    chunk.FeedData(xhtmlStream);
                    AltChunk altChunk = new AltChunk();
                    altChunk.Id = altChunkId;
                    doc.MainDocumentPart.Document.Body.Append(altChunk);
                }
                doc.MainDocumentPart.Document.Save();
                
            }
