    public class ClearFocusOnClickBehavior : Behavior<FrameworkElement>
        {
            public static readonly DependencyProperty ElementToClearFocusProperty = DependencyProperty.RegisterAttached("ElementToClearFocus", typeof(FrameworkElement), 
                                                                                typeof(ClearFocusOnClickBehavior), new UIPropertyMetadata());
    
    
            public FrameworkElement ElementToClearFocus
            {
                get { return (FrameworkElement)GetValue(ElementToClearFocusProperty); }
                set { SetValue(ElementToClearFocusProperty, value); }
            }
            protected override void OnAttached()
            {
                AssociatedObject.MouseDown += (sender, args) => 
                {
                    FrameworkElement ctrl = ElementToClearFocus; 
                    FrameworkElement parent = (FrameworkElement)ElementToClearFocus.Parent;
    
                    while (parent != null && parent is IInputElement
                                      && !((IInputElement)parent).Focusable)
                    {
                        parent = (FrameworkElement)parent.Parent;
                    }
    
                    DependencyObject scope = FocusManager.GetFocusScope(ElementToClearFocus); 
                    FocusManager.SetFocusedElement(scope, parent as IInputElement);
                };
                base.OnAttached();
            }
              
        }
