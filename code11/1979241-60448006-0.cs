    using System.Windows;
    using System.Windows.Interactivity;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    public class ListenKeyBehavior : Behavior<Window>
    {
        public Brush KeyBgBrush { get; set; }
        private Brush _originalBgBrush;
    
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
            AssociatedObject.PreviewKeyUp += AssociatedObject_PreviewKeyUp;
        }
    
        private void AssociatedObject_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var foundEl = GetChildByName(AssociatedObject, e.Key.ToString().ToLower()) as Shape;
            if (foundEl != null && KeyBgBrush != null && _originalBgBrush==null)
            {
                _originalBgBrush = foundEl.Fill;
                foundEl.Fill = KeyBgBrush;
            }
        }
    
        private void AssociatedObject_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var foundEl = GetChildByName(AssociatedObject, e.Key.ToString().ToLower()) as Shape;
            if (foundEl != null && _originalBgBrush != null)
            {
                foundEl.Fill = _originalBgBrush;
                _originalBgBrush = null;
            }
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
            AssociatedObject.PreviewKeyUp -= AssociatedObject_PreviewKeyUp;
            base.OnDetaching();
        }
        public static object GetChildByName(DependencyObject depObj, string searchedName) 
        {
            if (depObj == null)
            {
                return null;
            }
    
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                if (child is FrameworkElement childFrmWrkEl && childFrmWrkEl.Name.ToLower()==searchedName)
                {
                    return child;
                }
                var result = GetChildByName(child, searchedName);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
