    public partial class Search : UserControl
    {
        MyProgram.MVVM mvvm = new MyProgram.MVVM();
        public Search()
        {
            InitializeComponent();
            DataContext = mvvm;
        }
    
        protected void entryName_TextChanged(object sender, TextChangedEventArgs args)
        {
          mvvm.IsShowFrame = false;
        }
    
    }
