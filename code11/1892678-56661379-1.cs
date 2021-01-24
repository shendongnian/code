    using System.Windows;
    
    namespace XamDataGridUpdateTrigger
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                NamesCollection.Add(new NamesItem("Sport", "Chief"));
                InitializeComponent();
            }
    
            public NamesModel NamesCollection
            {
                get { return (NamesModel)GetValue(NamesProperty); }
                set { SetValue(NamesProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Names.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty NamesProperty =
                DependencyProperty.Register("NamesCollection", typeof(NamesModel), typeof(MainWindow), new PropertyMetadata(new NamesModel()));
    
            private void XamDataGrid1_CellChanged(object sender, Infragistics.Windows.DataPresenter.Events.CellChangedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine($"{e.Cell}"); // VIC:
            }
        }
    }
