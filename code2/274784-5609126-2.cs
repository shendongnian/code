      public class MyClass
        {
          XElement self;
          public MyClass(XElement self)
          {
             this.self = self;
          }
        
        public string Name
        {
          get { return (string)(self.Attribute("Name") ?? "some default value/null"); }
          set 
          { 
            XElement x = source.Attribute("Name");
            if(null == x)
              source.Add(new XAttribute("Name", value));
            else
              x.ReplaceWith(new XAttribute("Name", value));
          }
        }
       }
