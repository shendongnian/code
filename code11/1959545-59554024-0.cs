                if ((cmbCol.DataSource = myList(1)) == null)
                    return;
                cmbCol.Name = "Naam";
                cmbCol.DisplayMember = "";
                cmbCol.ValueMember = "Naam";
                dataGridView1.Columns.Insert(2, cmbCol); // there is no field with the name 'Naam'
            }
        }
        private List<string> myList(int col)
        {
            string connectionString = dBFunctions.ConnectionStringSQLite;
            helper = new dBHelper(connectionString);
            if (helper.Load("SELECT * FROM Klant ORDER BY Naam", ""))
            {
                List<string> results = new List<string>();
                DataSet ds = helper.DataSet;
                DataTable dt = ds.Tables[0];
                dataRow = helper.DataSet.Tables[0].Rows[0];
                foreach(DataRow row in dt.Rows)
                {
                    results.Add(row[col].ToString());
                }
                return results;
            }
            return null;
        }
