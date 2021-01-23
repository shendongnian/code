    public class MyViewModel
    {
        public ObservableCollection<MyData> List { get; set; }
    }
    public class MyView : UserControl
    {
        public MyView()
        {
            DataContext = new MyViewModel();
        }
    }
    <ListBox ItemsSource="{Binding List}" />
