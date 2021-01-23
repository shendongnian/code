    namespace System.Windows.Controls
    {
        public static class MyExt
        {
             public static void PerformClick(this Button btn)
             {
                 btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
             }
        }
    }
