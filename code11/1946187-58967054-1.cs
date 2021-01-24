DataContextExample myContext;
public SubWindow(DataContextExample context)
{
    myContext = context;
    DataContext = myContext;
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
Also, in your second window you are changing `Properties.Setting.Default` values directly, but you need to change the `DataContext` value.
private void Window_KeyUp(object sender, KeyEventArgs e)
{
     if (e.Key == Key.Enter)
     {
           myContext.strText = TxtBox.Text;           
     }
     //....
}
