    public void onlyDueReport()
        {
            List<int> array = new List<int>();
            string connectionPath = @"Data Source=Data\libraryData.dat;Version=3;New=False;Compress=True";
            using (SQLiteConnection connection = new SQLiteConnection(connectionPath))
            {
                SQLiteCommand command = connection.CreateCommand();
                connection.Open();
                string query = "SELECT bookno as 'Book No.',studentId as 'Student ID',  title as 'Title', author as 'Author', description as 'Description', issuedDate as 'Issued Date', dueDate as 'Due Date' FROM issuedBooks";
                command.CommandText = query;
                command.ExecuteNonQuery();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "issuedBooks");
                int c = ds.Tables["issuedBooks"].Rows.Count;
                if (c > 0)
                {
                    for (int row = c; row > 0; row--)
                    {
                        string date = (string)(ds.Tables["issuedBooks"].Rows[c - row]["Due Date"]);
                        if (isLate(date))
                        {
                            int a = Convert.ToInt32(ds.Tables["issuedBooks"].Rows[c - row]["Book No."]);
                            array.Add(a);
                        }
                    }
                }
                query = "SELECT bookno as 'Book No.',studentId as 'Student ID',  title as 'Title', author as 'Author', description as 'Description', issuedDate as 'Issued Date', dueDate as 'Due Date' FROM issuedBooks WHERE bookno IN (";
                int[] cool = array.ToArray();
                int cou = 0;
                foreach (int a in cool)
                {
                    query += a;
                    if (cou < cool.Length - 1) { query += ','; }
                    cou++;
                }
                query += ")";
                Console.WriteLine(query);
                command.CommandText = query;
                command.ExecuteNonQuery();
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "issuedBooks");
                dataGridView1.DataSource = ds1.Tables["issuedBooks"];
                this.Totals.Text = "";
                Report_Viewer.StatusPText = " Total Pending Books :  " + ds1.Tables["issuedBooks"].Rows.Count; 
            }
            
        }
