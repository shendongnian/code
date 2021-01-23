        static void Main(string[] args)
        {
            string connectionString  = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "d:\\temp\\customers.xlsx" + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
            string selectString = "INSERT INTO [Customers$](Id,Company) VALUES('12345', 'Acme Inc')";
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(selectString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
            Console.ReadLine();
        }
    }
