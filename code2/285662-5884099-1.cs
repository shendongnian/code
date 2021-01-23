    namespace BusinessObjects
    {
    [Export]
    public class MyClass
    {
        public MyClass()
        {
            DateTime = DateTime.Now;
        }
        public DateTime DateTime { get; set; }
    }
    }
