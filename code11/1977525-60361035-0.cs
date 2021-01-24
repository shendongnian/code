 c#
((MainWindow)this.Owner).MemberName
// or this way
(Owner as MainWindow).MemberName
The other way to access some (creator) class from other class is passing pointer to parent class as argument to its Constructor.
 c#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        OtherClass child = new OtherClass(this);
    }
}
public class OtherClass
{
    private MainWindow mainWindow;
    OtherClass (MainWindow parent)
    {
        mainWindow = parent;
    }
}
