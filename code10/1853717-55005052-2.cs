    public static class Helpers
    {
     public static void RunInUIThread(Action method)
       {
           if (Application.Current == null)
           {
               return;
           }
           Application.Current.Dispatcher.BeginInvoke((Action)delegate
           {
               method();
           });
       }
    }
