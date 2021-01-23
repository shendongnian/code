    class Program
    {
        static void Main(string[] args)
        {
            Byte myByte = 5;
            object myObject = (object)myByte;
            int myInt = myObject.GetValueOrDefault<Byte>();
            Console.WriteLine(myInt); // 5
            myObject = DBNull.Value;
            myInt = myObject.GetValueOrDefault<Byte>();
            Console.WriteLine(myInt); // 0
            Console.ReadKey(true);
        }
    }
    public static class ObjectExtension
    {
        public static T GetValueOrDefault<T>(this object value)
        {
            if (value == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)value;
            }
        }
    }
