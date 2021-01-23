     protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (fupImage.HasFile)
        {
                byte[] myByte = new byte[fupImage.PostedFile.ContentLength];
                Stream imgStream = fupImage.PostedFile.InputStream;
                imgStream.Read(myByte, 0, fupImage.PostedFile.ContentLength);
               e.Values["personal_image"] = myByte;           
        }
    }
