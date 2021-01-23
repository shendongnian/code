    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            lstTest.Items.Clear();
            var t1 = new MethodInfo
                         {
                             MethodName = "Test1", 
                             MethodToRun = this.Test1
                         };
            lstTest.Items.Add(t1);
            var t2 = new MethodInfo
                        {
                            MethodName = "Test2",
                            MethodToRun = this.Test2
                        };
            lstTest.Items.Add(t2);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var t = lstTest.SelectedItem as MethodInfo;
            if (t != null)
            {
                var a = new Task(t.MethodToRun);
                a.Start();
            }
        }
        private void Test1()
        {
            MessageBox.Show("Test1 started");
        }
        private void Test2()
        {
            MessageBox.Show("Test2 started");
        }
    }
    public class MethodInfo
    {
        public string MethodName;
        public Action MethodToRun;
        public override string ToString()
        {
            return MethodName;
        }
    }
