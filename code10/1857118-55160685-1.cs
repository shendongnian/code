    [ContentProperty(nameof(Options))]
    public partial class OptionsControl : UserControl
    {
        public OptionsControl()
        {
            InitializeComponent();
            Options = optionsPanel.Children;
        }
        public UIElementCollection Options { get; }
    }
