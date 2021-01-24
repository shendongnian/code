    public partial class LabelWithTextBox : UserControl
    {
        public LabelWithTextBox()
        {
            InitializeComponent();
        }
        private BindingBase textBinding;
        public BindingBase TextBinding
        {
            get { return textBinding; }
            set
            {
                textBinding = value;
                TextBox.SetBinding(RadWatermarkTextBox.TextProperty, textBinding);
            }
        }
    }
