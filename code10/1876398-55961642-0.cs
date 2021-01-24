    public void button1_Click(object sender, EventArgs e)
    {
        try {
           string conString = @"Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C:\Users\Youssef Salah\Documents\koko.mdf;Integrated Security=True;Connect Timeout=30";
           SqlConnection con = new SqlConnection(conString);
           con.Open(); // that line \\
           if (con.State == System.Data.ConnectionState.Open)
           {
               Console.WriteLine("Done!");
               string q = " INSERT INTO Users(ID_User,Name , Email_Address , passwordd) VALUES (3 ,'koko' , 'yoyo' , 'lala')";
               SqlCommand cmd = new SqlCommand(q, con);
               cmd.ExecuteNonQuery();
               MessageBox.Show("Connection Open  !");
           }
           con.Close();
       } catch (Exception ex) {
           MessageBox.Show(ex.Message);
       }
    }
