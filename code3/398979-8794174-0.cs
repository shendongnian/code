    public class FormWait
    {
         private static FormWait frm = new FormWait();
       
         public static void ShowForm(string message)
         {
             Show(message);
         }
    
         public static void Close()
         {
             Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                      if(!frm.Visible)
                          return;
    
                      frm .Close();
                }));
           
            
         }
    
         private void Show(string str)
         {
           Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                     if(frm.Visible)
                        frm.Close();
                     lblMessage.Text = message; // assume that there is a label on the Form to show the message
    
                      frm .Show();
                }));
           
            
         }
    
       } 
