      public partial class MainWindow : Window
        {
            List<ButtonDataGrid> data = new List<ButtonDataGrid>();
            public MainWindow()
            {
                InitializeComponent();
    
                for (int x = 0; x < 10; x++)
                {
                    ButtonDataGrid dataToAdd = new ButtonDataGrid();
    
                    dataToAdd.srNo = (x + 1).ToString();
                    dataToAdd.ArticleTitle = "This is Article No " + dataToAdd.srNo;
                    if (x % 2 == 0)
                        dataToAdd.Display = System.Windows.Visibility.Visible;
                    else
                        dataToAdd.Display = System.Windows.Visibility.Hidden;
                    data.Add(dataToAdd);
                }
                dataGrid1.ItemsSource = data;
            }
        }
        public class ButtonDataGrid
        {
            public string srNo { get; set; }
            public string ArticleTitle { get; set; }
            public Visibility Display { get; set; }
    
        }
