        private void Loginbutton_Click(object sender, EventArgs e)
        {
            int RecordCount = 0;
            using (MySqlConnection cn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=bruger"))
            {
                using (MySqlCommand command = new MySqlCommand("SELECT Count(*) FROM bruger WHERE password =@pass AND brugernavn =@usn", cn))
                {
                    command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxBrugernavn.Text;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
                    cn.Open();
                    RecordCount = (int)command.ExecuteScalar();
                }
            }
            if (RecordCount > 0)
            {
                MessageBox.Show("YES");
                //Add code to proceed to your next form
            }
            else
            {
                MessageBox.Show("NO");
            }
        }
