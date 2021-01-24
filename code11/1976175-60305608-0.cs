 c#
public partial class MainWindow : Window
{
    // make your list globally visible
    private List<string> taskList = new Tasklist {"Task A", "Task B", "Task C"}
    
    public MainWindow()
    {
        InitializeComponent();
        AddTaskButton.Click += AddTaskButton_Click;
    }
    private void AddTaskButton_Click(object sender, RoutedEventArgs e)
    {
        taskList.Add(); // add your values here
    }
}
