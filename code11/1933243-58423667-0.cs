c#
public UserControl1()
{
    InitializeComponent();
}
public string TextValue
{
    get { return (string)GetValue(TextValueProperty); }
    set { SetValue(TextValueProperty, value); }
}
// Using a DependencyProperty as the backing store for TextValue.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty TextValueProperty =
    DependencyProperty.RegisterAttached("TextValue", typeof(string), typeof(UserControl1), new PropertyMetadata(null, OnTextValueChange));
private static void OnTextValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
    UserControl1 userControl = (UserControl1)d;
    string value = (string)e.NewValue;
    if (userControl == null || value == null)
        return;
    userControl.textvalue.Text = value;
}
you don't need to bind the usercontrol to its code behind.
