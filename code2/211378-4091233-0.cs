    public static class ControlExtensions
    {
       public static void Do(this Control c, Action f)
       {
          if (c.InvokeRequired)
          {
             c.Invoke(f);
          }
          else
          {
             f();
          }
       }
    }
 
