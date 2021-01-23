    using System.Windows;
    using System.Xml.Linq;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MyDataGrid.xaml
        /// </summary>
        public partial class MyDataGrid : Window
        {
            public MyDataGrid()
            {
                InitializeComponent();
    
                var xml = XDocument.Load( "c:\\Somewhere\\Books.xml" ).Root;
                dataGrid1.DataContext = xml;
            }
    
        }
    }
