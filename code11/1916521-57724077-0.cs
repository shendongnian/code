    this.Close();
    Mainform mainform = new Mainform();
    mainform.Show();
    MessageBox.Show("Welcome!", "Validation App", 
    MessageBoxButtons.OK, MessageBoxIcon.Information);
    
    DateTime datetime = DateTime.Now;
    command = new SqlCommand("insert into 
    dbo.ValidationApp(lastlogin) values(@dtime)", cnn);
    command.Parameters.Clear();
    command.Parameters.Add("@dtime", SqlDbType.DateTime).SourceColumn = datetime.ToString();
    command.ExecuteNonQuery();
