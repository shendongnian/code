    protected void Button2_Click(object sender, EventArgs e)
    {
        Byte[] ar = Ret_image(Convert.ToInt32(TextBox2.Text));
        String st = Server.MapPath("abc.jpg");
        FileStream fs = new FileStream(st, FileMode.Create, FileAccess.Write);
        fs.Write(ar, 0, ar.Length);
        fs.Close();
        Image1.ImageUrl = "abc.jpg";           
    }
