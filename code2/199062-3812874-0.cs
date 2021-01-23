    using(System.IO.MemoryStream ms = new System.IO.MemoryStream(
         System.Text.Encoding.UTF16.GetBytes(yourString))
    {
        XYZ(ms);
    }
