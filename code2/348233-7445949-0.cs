    public class CollectionHelper
    {
        private CollectionHelper()
        {
        }
    
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
    
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
    
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
    
                table.Rows.Add(row);
            }
    
            return table;
        }
    
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
    
            if (rows != null)
            {
                list = new List<T>();
    
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
    
            return list;
        }
    
        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
    
            List<DataRow> rows = new List<DataRow>();
    
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
    
            return ConvertTo<T>(rows);
        }
    
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
    
                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }
    
            return obj;
        }
    
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
    
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
    
            return table;
        }
    }
    To see the full code in action, check this sample out:
    
    public class MyClass
    {
        public static void Main()
        {
            List<Customer> customers = new List<Customer>();
    
            for (int i = 0; i < 10; i++)
            {
                Customer c = new Customer();
                c.Id = i;
                c.Name = "Customer " + i.ToString();
    
                customers.Add(c);
            }
    
            DataTable table = CollectionHelper.ConvertTo<Customer>(customers);
    
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Customer");
                Console.WriteLine("---------------");
    
                foreach (DataColumn column in table.Columns)
                {
                    object value = row[column.ColumnName];
                    Console.WriteLine("{0}: {1}", column.ColumnName, value);
                }
    
                Console.WriteLine();
            }
    
            RL();
        }
    
        #region Helper methods
    
        private static void WL(object text, params object[] args)
        {
            Console.WriteLine(text.ToString(), args);
        }
    
        private static void RL()
        {
            Console.ReadLine();
        }
    
        private static void Break()
        {
            System.Diagnostics.Debugger.Break();
        }
    
        #endregion
    }
