    internal class MyViewModel
    {
        public ObservableCollection<Person> People = new ObservableCollection<People>();
    
        // code to populate People
    }
    
    public class MyWindow
    {
        public MyWindow()
        {
            DataContext = new MyViewModel();
        }
    }
