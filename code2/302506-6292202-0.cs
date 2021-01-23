        public int bla()
        {
            int itemsMin = -1;
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=tcp:**.****;Initial Catalog=*****;User ID=****;Password=****;Integrated Security=False;");
                string commandtext = "SELECT Minbuy FROM items";
                SqlCommand command = new SqlCommand(commandtext, connection);
                connection.Open();
                itemsMin = (int)command.ExecuteScalar();
                string commandtext2 = "SELECT purchaseid FROM purchase";
                SqlCommand command2 = new SqlCommand(commandtext2, connection);
                int purchase = (int)command2.ExecuteScalar();
                if (itemsMin >= purchase)
                    image3.Visible = true;
                else
                    image4.Visible = true;
                connection.Close();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
            return itemsMin;
        }
