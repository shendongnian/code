    public class MyEventArgs : EventArgs
    {
        public bool Value { get; set; }
    }
    public class MyClass
    {
        public void method1(ref bool b)
        {
            MyEventArgs e = new MyEventArgs()
            {
                Value = b
            };
            eventMethod(e);
            b = e.Value;
        }
        void eventMethod(MyEventArgs e)
        {
            e.Value = false;
        }
    }
