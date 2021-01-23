    public partial class DPTest : UserControl
    {
        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register(
            "Group",
            typeof(DPGroup),
            typeof(DPTest),
            new PropertyMetadata(
                new DPGroup(),
                new PropertyChangedCallback(OnGroupPropertyChanged)
                )
            );
        public DPGroup Group
        {
            get { return (DPGroup)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }
        // static method invoked when Group property has changed value
        // here we need to attach event handler defined if DPGroup, so it will fire from inside Group property, 
        // when Group.MyProperty1 will change value
        static void OnGroupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DPTest control = (DPTest)d;
            DPGroup oldGroup = e.OldValue as DPGroup;
            // removing event handler from prevoius instance of DBGroup
            if (oldGroup != null)            
                oldGroup.PropertyChanged -= new PropertyChangedEventHandler(control.group_PropertyChanged);
            
            DPGroup newGroup = e.NewValue as DPGroup;
            // adding event handler to new instance of DBGroup
            if (newGroup != null)            
                newGroup.PropertyChanged += new PropertyChangedEventHandler(control.group_PropertyChanged);
            
            DPTest g = d as DPTest;
            if (g != null)
                control.UpdateTextBox();            
        }
        private void group_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateTextBox();
        }
        // here you can do anything with changed value Group.MyProperty1
        private void UpdateTextBox()
        {
            this.textBox1.Text = this.Group.MyProperty1.ToString();
        }
        public DPTest()
        {
            InitializeComponent();
        }
    }  
