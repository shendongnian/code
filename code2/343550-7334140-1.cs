        class Program
        {
            static void Main(string[] args)
            {
                Type t = typeof(A7);
                FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
    
                foreach (FieldInfo fi in fields)
                {
                    Console.WriteLine(fi.Name);
                    Console.WriteLine(fi.GetValue(null).ToString());
                }
    
                Console.Read();
            }
        }
