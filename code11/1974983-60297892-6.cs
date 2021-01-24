     public partial class ucStatusFlag : UserControl
    {
        public ucStatusFlag()
        {
            InitializeComponent();
        }
        public string LabelContent
        {
            get { return (string)GetValue(LabelContentProperty); }
            set
            {
                SetValue(LabelContentProperty, value);
         
            }
        }
        public SolidColorBrush RectangleColor
        {
            get { return (SolidColorBrush)GetValue(RectangleColorProperty); }
            set
            {
                SetValue(RectangleColorProperty, value);
                
            }
        }
        public static readonly DependencyProperty RectangleColorProperty =
            DependencyProperty.Register("RectangleColor", typeof(SolidColorBrush), typeof(ucStatusFlag), new PropertyMetadata(Brushes.Gold));
      
        public static readonly DependencyProperty LabelContentProperty =
             DependencyProperty.Register("LabelContent", typeof(string), typeof(ucStatusFlag), new PropertyMetadata("LabelContent"));
    }
