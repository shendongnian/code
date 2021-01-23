            MyClass myClass = new MyClass();
            myClass.SetProperty("abc", 123);
            myClass.SetProperty("bcd", "bla");
            myClass.SetProperty("cde", DateTime.Now);
            MessageBox.Show(myClass.GetProperty("abc").ToString());
    class MyClass
    {
        private Hashtable MyProperties { get; set; }
        public MyClass()
        {
            MyProperties = new Hashtable();
        }
        public object GetProperty(string name)
        {
            return MyProperties.Contains(name) ? MyProperties[name] : null;
        }
        public void SetProperty(string name, object value)
        {
            if (MyProperties.Contains(name))
                MyProperties[name] = value;
            else
                MyProperties.Add(name, value);
        }
    }
