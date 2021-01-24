    private  void Check()
    {
          if (modified.Equals(true))
            {
                DialogResult dialogr = MessageBox.Show("Do you want to 
                save change ?","", MessageBoxButtons.YesNo);
                switch (dialogr)
                {
                    case DialogResult.Yes:
                        button_savenew.PerformClick();
                        modifie = false;
                        break;
                    case DialogResult.No:
                        return;
                }
            }
    
            modified = false;
            textBox_fn.Text = string.Empty;
            textBox_ln.Text = string.Empty;
    }
     private void button_modify_Click(object sender, EventArgs e)
     {
            if (conn.State != ConnectionState.Open) { conn.Close(); 
            conn.Open(); }
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE [Table1] SET [firstn]=[@firstn], 
            [lastn]=[@lastn] WHERE firstn = '" + 
            listBox1.SelectedItem.ToString() + "'";
            cmd.Parameters.AddWithValue("@firstn", textBox_fn.Text);
            cmd.Parameters.AddWithValue("@lastn", textBox_ln.Text);
            cmd.ExecuteNonQuery();
            fill_lb();
            Check(); //<--added here
            conn.Close();
    }
