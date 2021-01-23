        public Form1()
            {
            //Connect to Database to generate auto number
            NpgsqlConnection iConnect = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=pass;Database=DB");
            iConnect.Open();
            NpgsqlCommand iQuery = new NpgsqlCommand("Select * from table1", iConnect);
            NpgsqlDataReader iRead = iQuery.ExecuteReader();
            NpgsqlDataAdapter iAdapter = new NpgsqlDataAdapter(iQuery);
    
            DataSet iDataSet = new DataSet();
            iAdapter.Fill(iDataSet, "ID");
    
            MessageBox.Show(iDataSet.Tables["ID"].Rows.Count.ToString());
            //HERE LIES SOME CODES FOR RESIZING MY CONTROLS DURING RUNTIME
            //CODE
            //CODE AGAIN
            //ANOTHER CODE
            //CODE NA NAMAN
            //CODE PA RIN!
            }
