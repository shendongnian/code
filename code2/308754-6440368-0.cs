    class Program
    {
        static void Main(string[] args)
        {
            DataTable Matrix = new DataTable();
            Matrix.TableName = "Matrix";
            Matrix.Columns.Add(new DataColumn("Name     "));
            Matrix.Columns.Add(new DataColumn("1 England"));
            Matrix.Columns.Add(new DataColumn("2 Germany"));
            Matrix.Columns.Add(new DataColumn("3 France "));
            Matrix.Rows.Add("1 England", "   x   ", "       ", "       ");
            Matrix.Rows.Add("2 Germany", "       ", "   x   ", "       ");
            Matrix.Rows.Add("3 France ", "       ", "       ", "   x   ");
            PrintMatrix(Matrix);
            Console.WriteLine("Enter column number:");
            string sx = Console.ReadLine();
            int x = int.Parse(sx);
            Console.WriteLine("Enter row number:");
            string sy = Console.ReadLine();
            int y = int.Parse(sy);
            Console.WriteLine("Enter value:");
            string v = Console.ReadLine();
            SetValue(x, y, v, Matrix);
            PrintMatrix(Matrix);
            Console.ReadLine();
        }
        private static void SetValue(int x, int y, string value, DataTable table)
        {
            table.Rows[y - 1][x]=value;
        }
        private static void PrintMatrix(DataTable m)
        {
            string s = "|";
            foreach (DataColumn item in m.Columns)
            {
                s += item.ColumnName+"|";
            }
            Console.WriteLine(s);
            Console.WriteLine("---------------------------------");
            string j = "|";
            foreach (DataRow item in m.Rows)
            {
                foreach (object ob in item.ItemArray)
                {
                    j += ob.ToString()+"|";
                }
                Console.WriteLine(j);
                j = "|";
            }
            Console.WriteLine("---------------------------------");
        }
    }
