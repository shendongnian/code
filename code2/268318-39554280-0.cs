    student = txtStudent.Text;
                age = txtAge.Text;
                address = txtAddress.Text;
                section = CBSection.Text;
    
    
    
                string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\STI.accdb";
                string queryString = "UPDATE Details set StudentName='"+student+"',Age='"+age+"',Address='"+address+"' where Section/Course="+section+"";
                OleDbConnection connection = new OleDbConnection(ConnectionString);
                OleDbCommand command = new OleDbCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = queryString;
                command.Connection = connection;
                connection.Open();
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("StudentName : " + student + "\nAge : " + age + "\nAddress : " + address + "\nSection : " + section + "\nHas been successfully Enrolled");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }*strong text*
