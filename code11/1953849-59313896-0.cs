    public partial class MainWindow : Window
    {
       private _myVariables { get; set; }
       public MainWindow()
            {
                InitializeComponent();
                _myVariables = new MyVariables()
            }
    
       public class MyVariables
            {
                public List<int> pinNumbers = new List<int>();
            }
    
       private void PIN_0_Click(object sender, RoutedEventArgs e)
            {
                _myVariables.pinNumbers.Add(0);
                MessageBox.Show("List = " + _myVariables.pinNumbers);
    
            }
    
       private void PIN_1_Click(object sender, RoutedEventArgs e)
            {
                _myVariables.pinNumbers.Add(1);
            }
    }
