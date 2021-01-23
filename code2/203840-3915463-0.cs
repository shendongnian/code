    public class Program
    {
        static void Main(string[] args)
        {
            OleDbConnection conn = 
               new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=[put path to mdb here...]");
            
            conn.Open();
            
            OleDbCommand cmd = new OleDbCommand(
                "update Table1 set dateField = ? where textField like ?", 
                conn);
            cmd.Parameters.Add("@dateField", OleDbType.Date).Value = DateTime.Now;
            
            // IN THIS EXAMPLE, THE RECORD BEING UPDATED WILL HAVE "TEST"
            // IN THE FIELD NAMED: TEXTFIELD 
            cmd.Parameters.Add("@textField", OleDbType.VarChar).Value = "test";
            cmd.ExecuteNonQuery();
            
            conn.Close();
            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
