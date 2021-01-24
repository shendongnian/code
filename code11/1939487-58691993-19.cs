    public partial class addReorder : System.Windows.Window
    {
        public addReorder(string hvId) 
        {
          InitializeComponent();
          this.DataContext = new addReorderViewModel(hvId);
        }
    }
