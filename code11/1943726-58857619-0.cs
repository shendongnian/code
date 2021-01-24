    namespace DataTypeNamespaceTest
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new Test.ViewModel();
            }
        }
        namespace Test
        {
            public class ViewModel
            {
                public string Text { get; } = "Text in Test.ViewModel";
            }
        }
    }
