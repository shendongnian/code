    [ContentProperty(nameof(Options))]
    public partial class OptionsControl : UserControl
    {
        public UIElementCollection Options
        {
            get { return optionsPanel.Children; }
        }
        ...
    }
