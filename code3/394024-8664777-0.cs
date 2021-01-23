    // event_keyword.cs
    using System;
    public delegate void MyDelegate();   // delegate declaration
    
    public interface I 
    {
       event MyDelegate MyEvent;
       void FireAway();
    }
    
    public class MyClass: I 
    {
       public event MyDelegate MyEvent;
    
       public void FireAway() 
       {
          if (MyEvent != null)
             MyEvent();
       }
    }
    public class MainClass 
    {
       static private void f() 
       {
          Console.WriteLine("This is called when the event fires.");
       }
    
       static public void Main () 
       {
          I i = new MyClass();
    
          i.MyEvent += new MyDelegate(f);
          i.FireAway();
       }
    }
