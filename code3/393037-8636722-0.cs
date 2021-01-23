        da.InsertCommand = new SqlCommand("INSERT INTO Empolyee VALUES (@ESSN,@EFirstName,@ELastName,@EJob,@EBDate,@ESalary)", sqc);
        da.InsertCommand.Parameters.Add("@ESSN", SqlDbType.Int).Value = textBox1.Text;
        da.InsertCommand.Parameters.Add("@EFirstName", SqlDbType.VarChar).Value = textBox2.Text;
        da.InsertCommand.Parameters.Add("@ELastName", SqlDbType.VarChar).Value = textBox3.Text;
        da.InsertCommand.Parameters.Add("@EJob", SqlDbType.VarChar).Value = textBox4.Text;
        da.InsertCommand.Parameters.Add("@EBDate", SqlDbType.Date).Value = maskedTextBox1.Text;
        da.InsertCommand.Parameters.Add("@ESalary", SqlDbType.Int).Value = textBox5.Text;
