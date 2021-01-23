        //convert to stirng
        Bitmap bmp = new Bitmap(@"D:/bmp.bmp");
        MemoryStream mem = new MemoryStream();
        bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg );
        byte[] b = mem.ToArray();
        mem.Close();
        mem = null;
        System.Text.UnicodeEncoding a = new UnicodeEncoding();
        string s = System.Text.Encoding.Unicode .GetString(b);
        //test
        File.WriteAllText(@"D:/txt.txt", s);
       
        //convert back to image
        Image newImage;
        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);
        using (MemoryStream ms = new MemoryStream(bytes.Length))
        {
            ms.Write(bytes, 0, bytes.Length);
            newImage = Image.FromStream(ms);
            ms.Close();
        }
        //test 
        pictureBox1.Image = newImage;
        //It works!
        //So just fire the SQL
       con.Executenonquery("insert into ImageDb ('img') values (" + s +")") ;
