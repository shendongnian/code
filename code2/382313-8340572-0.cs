    public partial class MyCodeBehindCS : System.Web.UI.Page
    {     
        protected void Page_Load(object sender, EventArgs e)
        {
    
            MyNamespace.MyCustomClass myClass = new MyNamespace.MyCustomClass();
            myClass.Connect();
            var myResult = myClass.DoSomething();
    
        }
    }
