    class testSettings
    {
        public bool SetBool { get; set; }
        public void setProperty(object containingObject, string propertyName, object newValue) 
        {
             if (containingObject.GetType().GetProperties().Count(c => c.Name == propertyName) > 0)
            {
                containingObject.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, containingObject, new object[] { newValue });
            }
            else
            {
                throw new KeyNotFoundException("The property: " + propertyName + " was not found in: " + containingObject.GetType().Name);
            }
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
