    public partial class DialogOptions : ChildWindow
    {
        public DialogOptions()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                VerticalAlignment = VerticalAlignment.Top;
                this.SetWindowPosition(new Point(0, 200));
            };
        }
    }
