    using (MemoryStream ms = new MemoryStream())
    {
        Ekran.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        using (Attachment att = new Attachment(ms, "attach_name"))
        {
            ....
            client.Send(msg);
        }
    }
