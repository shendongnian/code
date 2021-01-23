    public void DoStuff()
    {
         MyObject myObject = GetMyObject();
         Console.WriteLine("Name: " + myObject.Name);
    }
    private MyObject GetMyObject()
    {
        using (MyObject obj = new MyObject())
        {
            obj.Name = "Aaron";
            return obj;
        }
    }
    public class MyObject : IDisposable
    {
        public String Name { get; set; }
        #region IDisposable Members
        public void Dispose()
        {
            //depends what you do in here...
        }
        #endregion
    }
