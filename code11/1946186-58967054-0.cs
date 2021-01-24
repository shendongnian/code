public SubWindow(DataContextExample context)
{
    DataContext = context;
    InitializeComponent();
}
Then call it like so in from your `MainWindow`
public MainWindow()
{
       InitializeComponent();
       DataContextExample context = new DataContextExample();
       SubWindow subWindow = new SubWindow(context);
       subWindow.Show();
       DataContext = context;
}
