    public class MyClass
    {
       public MyClass(){
       }
    
       public MyClass(XDocument xd)
       {
          var t = typeof(MyClass);
          var o = (MyClass)new XmlSerializer(t).Deserialize(xd.CreateReader());
    
          foreach (var property in t.GetProperties())
              property.SetValue(this, property.GetValue(o));
       }
    }
