    using (DocX doc = DocX.Create(@"Example.docx"))
    {
      using (MemoryStream ms = new MemoryStream())
      {
        System.Drawing.Image myImg = System.Drawing.Image.FromFile(@"test.jpg");
        myImg.Save(ms, myImg.RawFormat);  // Save your picture in a memory stream.
        ms.Seek(0, SeekOrigin.Begin);                    
        Novacode.Image img = doc.AddImage(ms); // Create image.
        Paragraph p = doc.InsertParagraph("Hello", false);
        Picture pic1 = img.CreatePicture();     // Create picture.
        pic1.SetPictureShape(BasicShapes.cube); // Set picture shape (if needed)
        p.InsertPicture(pic1, 0); // Insert picture into paragraph.
        doc.Save();
      }
    }
