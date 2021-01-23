    namespace ClassLibrary1
    {
        public partial class MyUserControl : UserControl
        {
            public MyUserControl()
            {
                //InitializeComponent();
                this.LoadViewFromUri("/ClassLibrary1;component/myusercontrol.xaml");
            }
        }
    }
