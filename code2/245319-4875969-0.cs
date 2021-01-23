    public class ConditionalControl : ContentControl
    {
        static ConditionalControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ConditionalControl), new FrameworkPropertyMetadata(typeof (ConditionalControl)));
        }
    
        #region Condition DP
    
        public bool Condition
        {
            get { return (bool) GetValue(ConditionProperty); }
            set { SetValue(ConditionProperty, value); }
        }
    
        public static readonly DependencyProperty ConditionProperty =
            DependencyProperty.Register("Condition", typeof (bool), typeof (ConditionalControl), new UIPropertyMetadata(false));
    
        #endregion
    
        #region TrueTemplate DP
    
        public DataTemplate TrueTemplate
        {
            get { return (DataTemplate) GetValue(TrueTemplateProperty); }
            set { SetValue(TrueTemplateProperty, value); }
        }
    
        public static readonly DependencyProperty TrueTemplateProperty =
            DependencyProperty.Register("TrueTemplate", typeof (DataTemplate), typeof (ConditionalControl), new UIPropertyMetadata(null));
    
        #endregion
    
        #region FalseTemplate DP
    
        public DataTemplate FalseTemplate
        {
            get { return (DataTemplate) GetValue(FalseTemplateProperty); }
            set { SetValue(FalseTemplateProperty, value); }
        }
    
        public static readonly DependencyProperty FalseTemplateProperty =
            DependencyProperty.Register("FalseTemplate", typeof (DataTemplate), typeof (ConditionalControl), new UIPropertyMetadata(null));
    
        #endregion
    }
