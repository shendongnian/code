csharp
public class MyDialog : Dialog
{
    public MyDialog(DialogVM ViewModel) {
        this.InitializeComponent();
        this.DataContex = ViewModel;
        // TODO: Bind to view model's properties in XAML or set them on OnClose()
    }
}
