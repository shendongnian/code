    Do not specify the column Id if it is primary key, then it will work fine
    private void btn_submit_Click(object sender, EventArgs e)   
        {
            con.Open();
            SqlCeCommand com = new SqlCeCommand("insert into Result(Name,RollNo,Age,Trade,Marks) values(@name,@rollno,@age,@trade,@marks)", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@name", name_txt.Text);
            com.Parameters.AddWithValue("@rollno", roll_txt.Text);
            com.Parameters.AddWithValue("@age", age_txt.Text);
            com.Parameters.AddWithValue("@trade", trade_txt.Text);
            com.Parameters.AddWithValue("@marks", marks_txt.Text);
            com.ExecuteNonQuery();
            MessageBox.Show("Submitted");
        }
