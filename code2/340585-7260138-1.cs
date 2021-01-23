    public class MyClass
    {
    public event EventHandler MyEvent;
    private int IsHandlingEvent = 0;
    public MyClass()
    {
      MyEvent += new EventHandler(MyClass_MyEvent);
    }
    void MyClass_MyEvent(object sender, EventArgs e)
    {
     // this allows for nesting if needed by comparing for example < 3 or similar
     if (Interlocked.Increment (ref IsHandlingEvent) == 1 )
     {
      try {
          }
      finally {};  
     } 
     Interlocked.Decrement (ref IsHandlingEvent);
    }
    }
 
