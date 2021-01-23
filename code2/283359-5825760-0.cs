    public class LabelEx : Label
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            UIElement elementToFocus = Target;
            if (elementToFocus == null && !string.IsNullOrEmpty(AssociatedControlName))
            {
                elementToFocus = this.FindName(AssociatedControlName) as UIElement;
            }
    
            if (elementToFocus != null)
            {
                elementToFocus.Focus();
            }
            base.OnMouseLeftButtonDown(e);
        }
    
        public String AssociatedControlName
        {
            get { return (String)GetValue(AssociatedControlNameProperty); }
            set { SetValue(AssociatedControlNameProperty, value); }
        }
    
        public static readonly DependencyProperty AssociatedControlNameProperty =
            DependencyProperty.Register("AssociatedControlName", typeof(String), typeof(LabelEx), new UIPropertyMetadata(String.Empty));
    }
