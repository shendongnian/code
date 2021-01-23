    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ...
            uxDataGrid.AddHandler( RequestBringIntoViewEvent, new RoutedEventHandler( HandleRequestBringIntoViewEvent ) );
        }
        private static void HandleRequestBringIntoViewEvent( object sender, RoutedEventArgs e )
        {
            e.Handled = true;
        }
        ...
    }
