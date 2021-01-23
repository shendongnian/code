     private void button2_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\pir fahim shah\Documents\TravelAgency.accdb";
         try
           {
               conn.Open();
               String ticketno=textBox1.Text.ToString();                 
               String Purchaseprice=textBox2.Text.ToString();
               String sellprice=textBox3.Text.ToString();
               String my_querry = "INSERT INTO Table1(TicketNo,Sellprice,Purchaseprice)VALUES('"+ticketno+"','"+sellprice+"','"+Purchaseprice+"')";
             
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfuly...!");
              }
             catch (Exception ex)
             {
                 MessageBox.Show("Failed due to"+ex.Message);
             }
             finally
             {
                 conn.Close();
             }
