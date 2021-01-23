       public static class ControlExtensions
       {
          public static void Invoke(this Control Control, Action Action)
          {
             Control.Invoke(Action);
          }
       }
