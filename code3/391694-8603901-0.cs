      public class MessageBoxWrapper
      {
        public static bool IsOpen {get;set;} 
    
        // give all arguments you want to have for your MSGBox
        public static void Show(string messageBoxText, string caption)
        {
         IsOpen = true;
         MessageBox.Show(messageBoxText, caption);
         IsOpen = false;
        }
      }
