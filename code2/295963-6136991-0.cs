    public class MyClass2
    {
        public int Id; 
        public string Name;
        public string Address;
        public MyClass2(MyClass1 a)
        {
            this.Name = a.Name;
            this.Address = a.Address;
        }
    }
