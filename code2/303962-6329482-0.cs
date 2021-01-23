    private static ArrayList arrayList;
    
        static void Main(string[] args)
        {
            arrayList = new ArrayList{1,2,3,4,5};
    
            var hello = "arrayList";
            var fieldInfo = typeof(Program).GetField(hello, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
    
            dynamic dyn = fieldInfo.GetValue(null);
            Console.WriteLine(dyn.Contains(5));
        }
