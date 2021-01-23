    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
    
            DataContext = new VM();
        }
    
        private void OnCheckBoxChecked(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (CheckBox checkBox in _checkBoxes.Where(cb => cb != sender))
            {
                checkBox.IsChecked = false;
            }
    
            (DataContext as VM).CurrentDrink = (sender as CheckBox).Content.ToString();
        }
    
        private void OnCheckBoxUnchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as VM).CurrentDrink = null;
        }
            
        private void OnCheckBoxLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _checkBoxes.Add(sender as CheckBox);
        }
    
        private List<CheckBox> _checkBoxes = new List<CheckBox>();
    }
    
    public class VM
    {
        public List<string> Drinks
        {
            get
            {
                return new List<string>() { "Coffee", "Tea", "Juice" };
            }
        }
    
        public string CurrentDrink { get; set; }
    }
