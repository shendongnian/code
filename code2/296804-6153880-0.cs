    public partial class MyUserControl : UserControl
    {
        public MyUserControl() {
            InitializeComponent();
    
            SetBinding(MyPropertyProperty,
                       new Binding {Path = new PropertyPath("MyViewModelProperty"), Mode = BindingMode.OneWayToSource});
        }
    }
