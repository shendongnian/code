    public partial class MenuPage : Page
    {
        public static readonly DependencyProperty MenuIconStyleProperty =
            DependencyProperty.Register("MenuIconStyle",
                                        typeof(Style),
                                        typeof(MenuPage),
                                        new UIPropertyMetadata(null));
        public Style MenuIconStyle
        {
            get { return (Style)GetValue(MenuIconStyleProperty); }
            set { SetValue(MenuIconStyleProperty, value); }
        }
        public static void SetMenuIconStyle(Page element, Style value)
        {
            element.SetValue(MenuIconStyleProperty, value);
        }
        public static Style GetMenuIconStyle(Page element)
        {
            return (Style)element.GetValue(MenuIconStyleProperty);
        }
        // ...
    }
