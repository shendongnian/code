    //unlock file by clearing it from picture box
    if (picturebox1.Image != null)
    {
       picturebox1.Image.Dispose();
       picturebox1.Image = null;
    }
    //put back the picture inside the pictureBox?
