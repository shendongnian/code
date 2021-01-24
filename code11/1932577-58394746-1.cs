    <Window x:Class="Test.MainWindow" ...>
       <Grid>
          <WrapPanel Margin="10">
             <Button Content="Test" Click="Button_Click" />
             <local:TestClassView x:Name="TestClassView" DataContext="{Binding TestClass}" />
          </WrapPanel>
       </Grid>
    </Window>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TestClass testClass = new TestClass() { Text = "DefaultProperty" };
        public TestClass TestClass { get { return testClass; } set { testClass = value; OnPropertyChanged(); } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            TestClass = new TestClass() { Text = "Test1" };
            MessageBox.Show("Test 1 Done");
            await Task.Delay(1000);
            TestClass = new TestClass() { Text = "Test2" };
            MessageBox.Show("Test 2 Done");
        }
    }
