    public partial class AusenciasBaseAdmin : UserControl
    {
        public static readonly RoutedEvent RowChangedEvent = EventManager.RegisterRoutedEvent("RowChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AusenciasBaseAdmin));
        public event RoutedEventHandler RowChanged
        {
            add { AddHandler(RowChangedEvent, value); } remove { RemoveHandler(RowChangedEvent, value); }
        }
        public AusenciasBaseAdmin()
        {
            InitializeComponent();
        }
        private void RegAusencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RaiseEvent(new SelectedRowEventArgs(RowChangedEvent, 1));
        }
    }
