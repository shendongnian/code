    public static class Watermark
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached( "Text",
                                                 typeof(Boolean),
                                                 typeof(Watermark),
                                                 new FrameworkPropertyMetadata() );
    
        public static void SetText( UIElement element, Boolean value )
        {
            element.SetValue( TextProperty, value );
        }
    
        public static Boolean GetText( UIElement element )
        {
            return (Boolean)element.GetValue( TextProperty );
        }
    }
