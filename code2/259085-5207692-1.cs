    using System.Collections.ObjectModel;
    using System.Windows;    
    public partial class MainWindow : Window
    {
        ObservableCollection<Car> cars = new ObservableCollection<Car>();
        public MainWindow()
        {
            InitializeComponent();            
            cars.Add(new Car("Volvo"));
            cars.Add(new Car("Ferrari"));
            cars_box.DataContext = cars;
        }
        private void add_car(object sender, RoutedEventArgs e)
        {
            cars.Add(new Car(new_car_box.Text));
        }
        private void delete_car(object sender, RoutedEventArgs e)
        {
            cars.Remove((cars_box.SelectedItem as Car));
        }
    }
    public class Car
    {
        public string name { get; set; }
        public Car(string _name)
        {
            this.name = _name;
        }
    }
