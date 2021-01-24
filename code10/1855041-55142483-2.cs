     private void Check()
        {
            if (conn.State != ConnectionState.Open) { conn.Close(); conn.Open(); }
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [table1] WHERE firstn='" + name + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
           
            foreach (DataRow dr in dt.Rows)
            {
                try // ignore null values
                {
                 
                    if (textBox_fn.Tag.ToString() != dr["firstn"].ToString()) { modified = true; }
                    if (textBox_ln.Tag.ToString() != dr["lastn"].ToString()) { modified = true; }
                }
                catch { }
            if (modified.Equals(true))
            {
                DialogResult dialogr = MessageBox.Show("Do you want to save change ? ", "", MessageBoxButtons.YesNo);
                switch (dialogr)
                {
                    case DialogResult.Yes:
                        button_savenew.PerformClick();
                        modified = false;
                        break;
                    case DialogResult.No:
                        modified = false;
                        return;
                }
            }
            modified = false;
          
        }
