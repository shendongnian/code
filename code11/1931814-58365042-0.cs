        private void Form1_Load(object sender, EventArgs e)
        { 
            string connectString = "provider=Microsoft.ACE.OLEDB.12.0;" + "data Source=C:\\Users\\Game-PC-Rick\\OneDrive - ROC Nova College\\C#\\Dell XPS Rick\\C# deel 3\\Vlinders\\Vlinders.accdb ; " + "Persist Security Info=False";
    
            long totalCount = 0;
    
            using (OleDbConnection con = new OleDbConnection(connectString))
            {
                con.Open();
                
                string sql2 = "SELECT familienamen.Familienaam, COUNT(familienamen.Familienaam) FROM familienamen Inner join vlinders ON Vlinders.Familienaam = Familienamen.Familie_Id GROUP BY familienamen.Familienaam ORDER BY familienamen.Familienaam";
                using (OleDbCommand dbcom2 = new OleDbCommand(sql2, con))
                {
                    using (OleDbDataReader dbcount = dbcom2.ExecuteReader())
                    {
                        while (dbcount.Read())
                        {
                            listBox1.Items.Add($"{dbcount[0].ToString()} {dbcount[1].ToString()});
    
                            totalCount++;
                        }
        
                        dbcount.Close();
                    }
                }
        
                con.Close();
            }
        }
  
