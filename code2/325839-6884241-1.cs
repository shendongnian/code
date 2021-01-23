     private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection  db = new SqlConnection("constring");
            SqlCommand com = new SqlCommand();
            SqlCommand com2 = new SqlCommand();
            SqlTransaction tran;
            db.Open();
            tran = db.BeginTransaction();
            try
            {
                //Run all your insert statements here here
                com.CommandText = "Insert into a(Date) Values(@Date)";
                com.Connection = db;
                com.Transaction = tran;
                com.Parameters.Add("@Date", SqlDbType.DateTime);
                com.Parameters["@Date"].Value = DateTime.Now;
                com.ExecuteNonQuery();
                com2.CommandText = "Insert into bb(name,amount) values(@name, @amount)";
                com2.Connection = db;
                com2.Transaction = tran;
                com2.Parameters.Add("@name", SqlDbType.VarChar, 25);
                com2.Parameters.Add("@amount", SqlDbType.Decimal);
                for (int i = 0; i < datagrid.Rows.Count; i++)
                {
                    //on each loop replace @name value and @amount value with appropiate
                    //value from your row collection
                    com2.Parameters["@name"].Value = datagrid.Rows[i].Cells["Name"].Value; 
                    com2.Parameters["@amount"].Value = datagrid.Rows[i].Cells["Amount"].Value;
                    com2.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (SqlException sqlex)
            {
                tran.Rollback();
            }
            finally
            {
                db.Close();
            }
        }
