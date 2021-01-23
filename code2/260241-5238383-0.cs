    public class MyPage
    {
        private MyClass myClass;
    
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!isPostBack)
            {
                myClass = (MyClass)Session["myClass"];
                myMethod1();
                myMethod1();
            }
        }
        
        private void myMethod1()
        {
            // use myClass here
        }
        
        private void myMethod2()
        {
            // use myClass here
        }
    }
