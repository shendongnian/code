    public class MainWindow : Window
    {
         // ...
         public MainWindow()
         {
             // Assigning to the DataContext is important
             // as all of the UIElement bindings inside the UI
             // will be a part of this hierarchy
             this.DataContext = new PoundViewModel();
             this.InitializeComponent();
         }
    }
