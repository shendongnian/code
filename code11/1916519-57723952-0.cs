     this.Close();
      Mainform mainform = new Mainform();
      mainform.Show();
      MessageBox.Show("Welcome!", "Validation App", 
      MessageBoxButtons.OK, MessageBoxIcon.Information);
      DateTime datetime = DateTime.Now;
      string format =  DateTime.Now.ToString();
      string format2=DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
      command = new SqlCommand("insert into 
      dbo.ValidationApp(lastlogin) values(@dtime)", cnn);
      command.Parameters.Clear();
      command.Parameters.Add("@dtime",datetime.ToString(format));
      command.ExecuteNonQuery();
