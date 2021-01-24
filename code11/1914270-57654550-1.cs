    public partial class MyPage1 : ContentPage
	{
        TestModel model;
		public MyPage1 ()
		{
			InitializeComponent ();
            
            model = new TestModel();
            BindingContext = model;       
		}
        private void Button_Clicked(object sender, EventArgs e)
        {
            model.LoadAsync();
        }
    }
