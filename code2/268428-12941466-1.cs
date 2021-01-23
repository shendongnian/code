    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    using TestDeDataGrid.TestDSTableAdapters;
    
    namespace TestDeDataGrid
    {
        
        public partial class MainWindow : Window
        {
            //private ICollection<TablaTest> registros;
    
            public MainWindow()
            {
                InitializeComponent();
              
                TestDS ds = new TestDS();
                TablaTestTableAdapter adapter = new TablaTestTableAdapter();
                adapter.Fill(ds.TablaTest);
    
                
                TablaTestGrid.ItemsSource = ds.TablaTest.DefaultView;
            }
    
          
            private void TablaTestGrid_CurrentCellChanged(object sender, EventArgs e)
            {
                if ((String)(((DataGrid)sender).CurrentColumn.Header) == "A/B")
                    ((DataGrid)sender).CommitEdit(DataGridEditingUnit.Row, true);
            }
        }
    }
