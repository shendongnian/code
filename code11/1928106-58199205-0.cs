c#
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void SetTextBoxValue(string value)
    {
        SampleTextBox.Text = value;
    }
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var otherWindow = new AnotherWindow(this);
        otherWindow.Show();
    }
}
**Other Window**
c#
public partial class AnotherWindow
{
    private readonly MainWindow _mainWindow;
    public AnotherWindow(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        InitializeComponent();
    }
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        _mainWindow.SetTextBoxValue("New value from other window");
    }
}
----------
**Method 2**
You can create a event for other window and subscribe to it in main window. like this:
**MainWindow**
C#
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var otherWindow = new AnotherWindow();
        otherWindow.TextBoxValueChanged += OtherWindowOnTextBoxValueChanged;
        otherWindow.Show();
    }
    private void OtherWindowOnTextBoxValueChanged(object sender, TextBoxValueEventArgs e)
    {
        SampleTextBox.Text = e.NewValue;
    }
}
**Other Window**
C#
public partial class AnotherWindow
{
    public event EventHandler<TextBoxValueEventArgs> TextBoxValueChanged;
    public AnotherWindow()
    {
        InitializeComponent();
    }
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var newValue = "New value from other window";
        OnTextBoxValueChanged(new TextBoxValueEventArgs(newValue));
    }
    protected virtual void OnTextBoxValueChanged(TextBoxValueEventArgs e)
    {
        TextBoxValueChanged?.Invoke(this, e);
    }
}
public class TextBoxValueEventArgs : EventArgs
{
    public string NewValue { get; set; }
    public TextBoxValueEventArgs(string newValue)
    {
        NewValue = newValue;
    }
}
**OUTPUT**
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/v6k87.gif
