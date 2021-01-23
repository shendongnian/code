            List<int> results = new List<int>();
            com.Parameters.AddWithValue("date", Form1.date);
            SqlCeDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                int resultsoutput = reader.GetInt32(0);
                results.Add(resultsoutput);
                // I wouldn't use a MessageBox in this loop
                // MessageBox.Show(resultsoutput.ToString());
            }
