    var filesRequest = Request.Form;
        string file = filesRequest["file_1"];
        byte[] bytes = Convert.FromBase64String(file); // Replace file here
        System.Drawing.Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = System.Drawing.Image.FromStream(ms);
        }
