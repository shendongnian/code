class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Evaluate("(4+8)*2"));
            Console.ReadKey();
        }
        public static double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
    } 
