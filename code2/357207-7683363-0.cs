     private void button1_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE tbl_Fullname SET Firstname=?,Lastname=?,Middlename=? WHERE fnID=?", conn);
    
            cmd.Parameters.Add("@firstn", OleDbType.VarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@lastn", OleDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@midn", OleDbType.VarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@idn", OleDbType.VarChar).Value = textBox5.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
