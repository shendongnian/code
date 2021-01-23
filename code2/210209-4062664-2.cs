    public class Foo
    {
       private object barLock = new object();
       private int bar;
    
       public void Add(int x)
       {
            lock (barLock)
            {
                this.bar += x;
            }
       }
    }
