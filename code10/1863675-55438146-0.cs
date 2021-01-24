    using Windows.UI.Xaml;
    ...
    public string welcomeText
    {
         get { return (string)GetValue(welcomeTextProperty); }
         set { SetValue(welcomeTextProperty, value); }
    }
    // Using a DependencyProperty as the backing store for welcomeText.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty welcomeTextProperty =
            DependencyProperty.Register("welcomeText", typeof(string), typeof(LoginPage), null);
