    class Functions 
    {
       public static void myMethod()
       {
           WebForm1 myMainForm;
           myMainForm = (WebForm1)System.Web.HttpContext.Current.Handler;
           TextBox myTextBox = myMainForm.myTextBox;
       }
    }
