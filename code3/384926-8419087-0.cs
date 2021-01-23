    PdfReader reader = new PdfReader(file1);
    using (FileStream fs = new FileStream(file2, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        using (PdfStamper stamper = new PdfStamper(reader, fs))
        {
            TextField tf = new TextField(stamper.Writer, new iTextSharp.text.Rectangle(0, 0, 100, 300), "Vertical");
            //Change the orientation of the text
            tf.Rotation = 90;
            stamper.AddAnnotation(tf.GetTextField(), 1);
        }
    }
