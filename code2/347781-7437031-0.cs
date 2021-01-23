    public class Form1 
    {
       public bool IsBackgroundWorkerStillRunning {get {....};}
    }
    public class Form2 
    {
        Form1 form1 = null;
        public Form2(Form1 frm1)
        {
          form1 = frm1;
        }
         private void OnSubmit(...)
         {
             if(form1.IsBackgroundWorkerStillRunning )
                  //wait 
             else
                  //proceed
         }
    }
