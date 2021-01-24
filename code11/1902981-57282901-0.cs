C#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public static StringCollection GetMyProperty(MainWindow wnd)
    {
        return wnd._myProperty;
    }
    private StringCollection _myProperty = new StringCollection();
}
public class StringCollection : ObservableCollection<String>
{
}
XAML
<local:MainWindow.MyProperty>
    <sys:String>Foo</sys:String>
</local:MainWindow.MyProperty>
