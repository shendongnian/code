    public YourPage: BaseClass
    {
         public void MyMethod()
         {
             base.BaseMethod();
         }
    }
    
    public BaseClass: System.Web.UI.Page
    {
        //.. your shared method goes here
        protected BaseMethod()
        {
             //.. logic here
        }
    }
