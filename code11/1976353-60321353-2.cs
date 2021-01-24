     public partial class My_Page: Page
     {
            public My_Page()
            {
                InitializeComponent();
                this.DataContext = new Test_ViewModel(); //assign ViewModel class
            }
           
            //...
      }
