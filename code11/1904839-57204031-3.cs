XAML
<Grid>
    <TextBox 
        x:Name="IntBox" 
        Margin="0, 5, 10, 5"
        Style="{StaticResource TextBoxInError}"
        />
</Grid>
Code behind:
C#
public partial class IntTextBox : UserControl
{
    public IntTextBox()
    {
        InitializeComponent();
    }
    public String PropertyPath
    {
        get { return (String)GetValue(PropertyPathProperty); }
        set { SetValue(PropertyPathProperty, value); }
    }
    public static readonly DependencyProperty PropertyPathProperty =
        DependencyProperty.Register(nameof(PropertyPath), typeof(String), 
            typeof(IntTextBox),
            new FrameworkPropertyMetadata(PropertyPath_PropertyChanged));
    protected static void PropertyPath_PropertyChanged(DependencyObject d, 
        DependencyPropertyChangedEventArgs e)
    {
        var ctl = d as IntTextBox;
        var binding = new Binding(ctl.PropertyPath)
        {
            ValidationRules = { new IntRule() },
            //  Optional. With this, the bound property will be updated and validation 
            //  will be applied on every keystroke. Fine for integers. For doubles 
            //  or phone numbers, it'll drive your users up the wall. 
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        };
        ctl.IntBox.SetBinding(TextBox.TextProperty, binding);
    }
}
I'm not sure what you're doing here is necessarily a good idea in this particular case, but the technique is respectable and that's how you do it. 
