    class Program
    {
        static void Main(string[] args)
        {
            dic = new Dictionary<int, MyStruct>();
            
            MyStruct s = new MyStruct(){ Isclosed=false};
            dic.Add(1,s);
            dic[1].Isclosed = true;
            Console.WriteLine(dic[1].Isclosed.ToString()); //will print out true...
            Console.Read();
        }
        static Dictionary<int, MyStruct> dic;
        public class MyStruct
        {
            public bool Isclosed;
            public bool Closed
            {
                get { return Isclosed; }
                set { Isclosed = value; }
            }
        }
    }
