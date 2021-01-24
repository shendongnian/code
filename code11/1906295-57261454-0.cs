     private void button1_Click(object sender, EventArgs e)
        {
            var mainconn = ConfigurationManager.ConnectionStrings["Delivery_Inspection.Properties.Settings.TransitiondayConnectionString"].ConnectionString;
            using (var sqlconn = new SqlConnection(mainconn))
            {
                sqlconn.Open();
                var query = "INSERT into Table1(Busnumber,Remarks,Dt1check1)VALUES (@bn,@rm,@dt1)";
                using (var command = new SqlCommand(query, sqlconn))
                {
                    command.Parameters.AddWithValue("@bn", label1.Text.ToString());
                    command.Parameters.AddWithValue("@rm", richTextBox1.Text.ToString());
                    command.Parameters.AddWithValue("@dt1", this.dataGridView1[1, 0].Value);
                    var result = command.ExecuteNonQuery();
    
                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
