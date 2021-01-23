    SqlConnection con = new SqlConnection();
    string _path;
    Using SYstem.IO;
    Using System.Data.SQLClient;
    //convert Image to binary and save in DB
    private void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            _path = openFileDialog1.FileName;
            InsertInSQL(_path);
        }
    }
    private void InsertInSQL(string _path)
    {
        con.ConnectionString = Pic.Properties.Settings.Default.ConnectionS;
        string strQ = "insert into dbo.PicTBL(Pic)values(@p)";
        SqlCommand command = new SqlCommand(strQ,con);
        command.Parameters.AddWithValue("@p",ImageToBinary(_path));
        con.Open();
        command.ExecuteNonQuery();
        con.Close();
    }      
    public static byte[] ImageToBinary(string _path)
    {
        FileStream fS = new FileStream(_path, FileMode.Open, FileAccess.Read);
        byte[] b = new byte[fS.Length];
        fS.Read(b, 0, (int)fS.Length);
        fS.Close();
        return b;
    }
    //Convert Binary to imge and save in a folder
    private void button1_Click_1(object sender, EventArgs e)
    {
        DataTable dt = Rimage();
        foreach (DataRow row in dt.Rows)
        {
            byte[] b = (byte[])row["Pic"];
            Image img = BinaryToImage(b);
            img.Save("D:\\NewFolder\\" + row["ID"].ToString() + ".jpg");
        }
    }
    private Image BinaryToImage(byte[] b)
    {
        if (b == null) 
            return null;
    
        MemoryStream memStream = new MemoryStream();
        memStream.Write(b, 0, b.Length);
        return Image.FromStream(memStream);
    }
    private DataTable Rimage()
    {
        con.ConnectionString = Pic.Properties.Settings.Default.ConnectionS;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from dbo.PicTBL";
        cmd.Connection = con;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        con.Open();
        adp.Fill(dt);
          
        return dt;
    }
