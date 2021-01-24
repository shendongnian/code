      var myImageFullPath = "https://zeminprogram-debb.restdb.io/media/uydu.png";
            using (DocX document = DocX.Create(@Application.StartupPath + "\\dene.doc"))
            {
                // Add an image into the document.    
                Xceed.Document.NET.Image image = document.AddImage(myImageFullPath);
                // Create a picture (A custom view of an Image).
                Picture picture = image.CreatePicture();
                // Insert a new Paragraph into the document.
              
                // Insert a new Paragraph into the document.
                Paragraph p1 = document.InsertParagraph();
                // Append content to the Paragraph
                p1.AppendLine("LOGO").AppendPicture(picture).Append(" its funky  don't you think?");
                p1.AppendLine();
                p1.AppendPicture(picture);
                document.Save();
                // Save this document.
            }
