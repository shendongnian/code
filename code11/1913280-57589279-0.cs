        using (SqlConnection con = new SqlConnection("**"))
        {
            con.Open();
            using (SqlCommand com = new SqlCommand("UPDATE indebtedness SET collected=@collected,Payment_Date=@Payment_Date WHERE Subscriber_No=@Subscriber_No and company_name=@company_name and indebtedness_name=@indebtedness_name", con))
            {
                com.Parameters.AddWithValue("@company_name", company_name.Text);
                com.Parameters.AddWithValue("@indebtedness_name", indebtedness_name.Text);
                com.Parameters.Add("@Payment_Date", SqlDbType.Date);
                com.Parameters.Add("@Subscriber_No", SqlDbType.BigInt);
                com.Parameters.Add(new SqlParameter("@collected", SqlDbType.Decimal) { Precision = 18, Scale = 3 } );
                int countSuccess = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    com.Parameters["@Subscriber_No"].Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    com.Parameters["@collected"].Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                    com.Parameters["@Payment_Date"].Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value); //hope this is a date, not a string. If it's a string, parse it instead
                    int numUpd = com.ExecuteNonQuery();
                    countSuccess += numUpd;
                }
                
                MessageBox.Show($"Successfully UPDATED {countSuccess} of {dataGridView1.Rows.Count} rows" );
            }
        }
