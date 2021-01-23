    public class MenuPageBase : Page
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
    }
