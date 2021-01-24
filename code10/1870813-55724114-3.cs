    public class MyButtonItem
    {
        public ImageSource Image { get; set; }
        public ICommand Command { get; set; }
        public string TooltipText { get; set; }
    }
    public partial class MyCustomControl : UserControl
    {
        public MyCustomControl()
        {
            InitializeComponent();
        }
        public ObservableCollection<MyButtonItem> Buttons { get; }
            = new ObservableCollection<MyButtonItem>();
    }
