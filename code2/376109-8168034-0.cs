    public class WinformBase : Winform
    {
         public WinformBase (){
         }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Controller.MyMethod();
        }
         
    }
    
    public class MyForm : WinformBase
    {
          public MyForm (){
          }
    }
