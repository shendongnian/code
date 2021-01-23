    public class LabeledControl : ContentControl
    {
        public LabeledControl()
        {
            this.DefaultStyleKey = typeof(LabeledControl);
        }
        #region public string Label
        public string Label
        {
            get { return GetValue(LabelProperty) as string; }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                "Label",
                typeof(string),
                typeof(LabeledControl),
                new PropertyMetadata(null));
        #endregion public string Label
    }
