    this.Close();
    Mainform mainform = new Mainform();
    mainform.Show();
    MessageBox.Show("Welcome!", "Validation App", 
    MessageBoxButtons.OK, MessageBoxIcon.Information);
    DateTime datetime = DateTime.Now;
    string format = "yyyy/MM/dd, HH:mm:ss";
    command = new SqlCommand("insert into 
    dbo.ValidationApp(lastlogin) values(@dtime)", cnn);
    command.Parameters.Add("@dtime", SqlDbType.DateTime).Value = DateTime.Now;
    try{
       if (cnn.State == ConnectionState.Closed)
       {
         cnn.Open();
       }
       command.ExecuteNonQuery();
    }
    finally{
      cnn.Close();
    }
