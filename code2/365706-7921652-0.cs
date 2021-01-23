    public class MyClass
    {
      private XmlSerializer _s = new XmlSerializer(typeof(MyClass));
      private static MyClass mInstance = null;
      public MyClass() { /* initialization logic */ }
      public MyClass(XDocument xd) 
      {
          mInstance = (MyClass)_s.Deserialize(xd.CreateReader());
      }
      public void DoSomething()
      {
         if (mInstance != null)
           mInstance.DoSomething();
         else 
         {
             // logic for DoSomething
         }
      }
    }
