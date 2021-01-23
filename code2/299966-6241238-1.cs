    class Program
    {
        static void Main(string[] args)
        {
            var permissionMap = new PermissionMap(new[] { "Read", "Write" });
            permissionMap.AddUser("Bill");
            permissionMap.AddUser("Jane");
            permissionMap["Bill", "Read"] = Permission.Allow;
            permissionMap["Jane", "Write"] = Permission.Allow;
            foreach (DataColumn column in permissionMap.Columns)
            {
                Console.Write(column.ColumnName);
                Console.Write(",");
            }
            Console.WriteLine();
            foreach (DataRow row in permissionMap.Rows)
            {
                foreach (DataColumn column in permissionMap.Columns)
                {
                    Console.Write(row[column]);
                    Console.Write(",");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
