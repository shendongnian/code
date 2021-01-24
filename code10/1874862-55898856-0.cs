    public class Table
    {
        // cache is private so it cannot be manipulated from outside
        private static Dictionary<int,Table> tables = new Dictionary<int, Table>();
        // constructor is private so Table can be created by the GetTable factory method
        private Table(int id)
        {
            //...
        }
        // the factory method that transparently returns the table either from cache or by creating one
        public static Table GetTable(int id)
        {
             if (tables.TryGetValue(id, out Table result))
                 return result;
             result = new Table(id);
             tables[id] = result;
             return result;
        }
    }
