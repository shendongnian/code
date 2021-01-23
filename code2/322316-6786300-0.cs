    class Program
    {
        static void Main()
        {
            List<MyData> list = new List<MyData>();
            // load the data (replace this with a loop over the file)
            list.Add(new MyData { Key = "B", Value = 67 });
            list.Add(new MyData { Key = "C", Value = 45 });
            list.Add(new MyData { Key = "A", Value = 15 });
            list.Add(new MyData { Key = "D", Value = 10 });
            // sort it
            list.Sort((x,y)=> y.Value.CompareTo((x.Value)));
            // show that it is sorted
            foreach(var item in list)
            {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
        }
    }
    internal class MyData
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
