    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Test> tests { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            tests = new ObservableCollection<Test>();
            for (int i = 0; i < 15; i++)
            {
                if (i < 7)
                {
                    tests.Add(new Test() { Name = "Name " + i, Color1 = new SolidColorBrush(Colors.Yellow), Color2 = new SolidColorBrush(Colors.Red) });
                }
                else
                {
                    tests.Add(new Test() { Name = "Name " + i, Color1 = new SolidColorBrush(Colors.Green), Color2 = new SolidColorBrush(Colors.LightBlue) });
                }
            }
            this.DataContext = this;
        }
    }
    public class Test
    {
        public string Name { get; set; }
        public SolidColorBrush Color1 { get; set; }
        public SolidColorBrush Color2 { get; set; }
    }
