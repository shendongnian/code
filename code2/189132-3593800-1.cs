        public partial class MyPage2: System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
               MyPage1.MyTestFunction();  // static function call
                 
               //or
               MyPage1 page1 = new MyPage1();
               page1.MyTestFunction2();           
            }
    
          }
