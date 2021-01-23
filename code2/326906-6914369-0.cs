    public class A 
    {
        public List<B> _listOfB;
        public string Name { get; set; }
        public List<B> ListOfB 
        {
            get { return _listOfB; }
        }
        public A() 
        {
            ListOfB = new List<B>();
        }
        public void AddB(B b) 
        {
            B.InstanceOfA = this;
            ListOfB.Add(b);
        }
        
        
    }
    public class B 
    {
        public A InstanceOfA { get; set; }
    }
