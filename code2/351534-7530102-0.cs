    using (MemoryStream ms = new MemoryStream())
    {
        Ekran.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        Attachment att = new Attachment(ms, "attach_name");
        ....
        client.Send(msg);
    }
