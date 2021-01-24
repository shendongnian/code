    public partial class Page5 : ContentPage
	{
		public Page5 ()
		{
			InitializeComponent ();
		}
        viewmodel vm = new viewmodel();
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            vm.listfirm = new List<string>();
            vm.listfirm.Add("test");
        }
    }
    public class viewmodel
    {
        public List<string> listfirm { get; set; }
    }
