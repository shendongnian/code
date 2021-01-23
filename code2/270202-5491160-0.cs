    private void Form2_Load(object sender, EventArgs e)
    {
        string connectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\\Documents and Settings\\Harvey\\Desktop\\Test.accdb");
        using (OleDbConnection conGet = new OleDbConnection(connectionString))
        using (OleDbCommand cmdGet = new OleDbCommand())
        try
        {
            cmdGet.CommandType = CommandType.Text;
            cmdGet.Connection = conGet;
            cmdGet.CommandText = "SELECT * FROM Paragraph";
            StringBuilder paragraph = new StringBuilder();
            //open connection
            conGet.Open() 
            using (OleDbDataReader rdr = cmdGet.ExecuteReader())
            {
                while (rdr.Read())
                {
                   parapraph.Append(rdr.GetString(0)).Append(" ");
                }
                rdr.Close();
            }
            richTextBox.Rtf = paragraph.ToString();
            // OR...
            richTextBox.Text = paragraph.ToString();
        }
        catch (Exception ex)
        {
            //display generic error message back to user
            MessageBox.Show(ex.Message);
        }
    }
