    class testSettings
    {
        public bool SetBool { get; set; }
        public void setProperty(object containingObject, string propertyName, object newValue) 
        {
            containingObject.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, containingObject, new object[] { newValue }); 
        }
    }
    static void Main(string[] args)
    {
        testSettings ts = new testSettings();
        ts.SetBool = false;
        ts.setProperty(ts, "SetBool", true);
        Console.WriteLine(ts.SetBool.ToString());
        Console.Read();
    }
