    using System;
    using System.Reflection;
   
    public class A {
        protected string a;
    }
    public class B : A {
    }
    public class Test{
      static void Main() {
          //get the type of the class
           var b = new B(); 
            Type type = b.GetType();
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
    
            // get the field info
            FieldInfo finfo = type.GetField("a", bindingFlags);
    
            // set the value 
            finfo.SetValue(b, "Hello World!");
    
            // get the value
            object someThingField = finfo.GetValue(b);
            Console.WriteLine(someThingField);
            
        
      }
    }
    
 
