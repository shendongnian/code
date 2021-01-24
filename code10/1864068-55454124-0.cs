    public class MyClass : IComparable<MyClass>
    {
        public string Name
        {
            get;
            set;
        }
        public int Desc
        {
            get;
            set;
        }
        public int CompareTo(MyClass other)
        {
            return Name.CompareTo(other.Name);
        }
    }
    public class MyList<T> : List<T> where T : IComparable<T>
    {
        public new void Add(T item)
        {          
            if (base.Count == 0)
            {
                base.Add(item);
                return;
            }
            if (base[base.Count - 1].CompareTo(item) <= 0)
            {
                base.Add(item);
                return;
            }
            if (base[0].CompareTo(item) >= 0)
            {
                base.Insert(0, item);
                return;
            }
            int index = base.BinarySearch(item);
            if (index < 0)
                index = ~index;
            base.Insert(index, item);
            base.Add(item);
        }
    }
       static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.Name = "B";
            MyClass myClass1 = new MyClass();
            myClass1.Name = "A";
            MyClass myClass2 = new MyClass();
            myClass2.Name = "C";
            MyClass myClass3 = new MyClass();
            myClass3.Name = "A";
            MyList<MyClass>mylist= new MyList<MyClass>();
            mylist.Add(myClass);
            mylist.Add(myClass1);
            mylist.Add(myClass2);
            mylist.Add(myClass3);
            Console.ReadKey();
        }
