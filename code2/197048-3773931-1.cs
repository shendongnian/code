    namespace CheckTest
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<SelectedDecorator<Foo>> Foos { get; set; }
            public MainWindow()
            {
                var bars = new List<Foo>() { new Foo() { Name = "Bob", Age = 29 }, new Foo() { Name = "Anne", Age = 49 } };
                var selectableBars = bars.Select(_ => new SelectedDecorator<Foo>(_)).ToList();
                Foos = new ObservableCollection<SelectedDecorator<Foo>>(selectableBars);
                InitializeComponent();
                DataContext = this;
            }
    
            private void btnSave_Click(object sender, RoutedEventArgs e)
            {
                var saveThese = Foos.ToList().Where(_ => _.Selected).Select(_=> _.Value);
                //db.BulkUpdate(saveThese); ... or some sutch;
            }
        }
        public class Foo
        {
            public string Name{get;set;}
            public int Age { get; set; }
        }
        public class SelectedDecorator<T>
        {
            public T Value { get; set; }
            public bool Selected { get; set; }
            public SelectedDecorator(T value)
            {
                Selected = false;
                this.Value = value;
            }
        }
    }
