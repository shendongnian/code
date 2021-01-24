static void Main(string[] args)
    {
        var list1 = new List<int>();
        list1.Add(1);
        list1.Add(2);
        list1.Add(3);
        list1.Add(4);
        list1.Add(5);
       foreach(int i in list1)
        {
            Console.WriteLine(i);
        }
However, what I am guessing you are asking is what is required to use foreach on your own type.
The answer is a bit of compiler magic of duck typing. If your iteration class implements a method called GetEnumerator() returning a type complying with certain rules (a MoveNext method taking no parameters and returning a bool and a Current Property you are good to go, see the most useless iterator ever below:
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var x= new MyIterable();
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class MyIterable
    {
        public Item Current { get; set; }
        public bool MoveNext()
        {
            return false;
        }
        public MyIterable GetEnumerator()
        {
            return this;
        }
    }
    public class Item
    {
    }
See https://blogs.msdn.microsoft.com/kcwalina/2007/07/18/duck-notation/
