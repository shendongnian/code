    var myImageFullPath = "C:\tmp\sample.png";
    using (DocX document = DocX.Create(@"docs\HelloWorldAddPictureToWord.docx"))
    {
      // Add an image into the document.    
      Image image = document.AddImage(myImageFullPath);
      // Create a picture (A custom view of an Image).
      Picture picture = image.CreatePicture();
      // Insert a new Paragraph into the document.
      Paragraph title = document.InsertParagraph().Append("This is a test for a 
      picture").FontSize(20).Font(new FontFamily("Comic Sans MS"));
      title.Alignment = Alignment.center;
      // Insert a new Paragraph into the document.
      Paragraph p1 = document.InsertParagraph();
     // Append content to the Paragraph
     p1.AppendLine("Check out this picture ").AppendPicture(picture).Append(" its funky 
     don't you think?");
     p1.AppendLine();
     p1.AppendPicture(picture);
     // Save this document.
     document.Save();
    }
