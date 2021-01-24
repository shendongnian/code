        private void createDatabase_Click(object sender, EventArgs e)
        {
            string constring = "Data Source =HALLR3C04;User ID=sa;Password=123456;";
            SqlConnection connstringsql = new SqlConnection(constring);
            //create table
            connstringsql.Open();
            string sqlqueryone = "CREATE DATABASE " + textBoxDatabaseName.Text;
            SqlCommand sqlcomm = new SqlCommand(sqlqueryone, connstringsql);
            sqlcomm.ExecuteNonQuery();
            connstringsql.Close();
            listBoxDatabases.Items.Add(textBoxDatabaseName.Text);
        }
        private void createTable_Click(object sender, EventArgs e)
        {
            string constring = $"Data Source =HALLR3C04;User ID=sa;Initial Catalog = {listBoxDatabases.SelectedItem.ToString()};Password=123456;";
            SqlConnection connstringsql = new SqlConnection(constring);
            //create table
            connstringsql.Open();
            string sqlqueryone = $@"create table {textBoxTableName.Text}
                                    (
                                        Id int IDENTITY PRIMARY KEY,
                                        Name VARCHAR(50)
                                    ) ";
            SqlCommand sqlcomm = new SqlCommand(sqlqueryone, connstringsql);
            sqlcomm.ExecuteNonQuery();
            connstringsql.Close();
        }
