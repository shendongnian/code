    public partial class Window1 : Window
    {
      private ObservableCollection<Customers> customers;
      public Window1()
      {
          InitializeComponent();
          this.customers = new ObservableCollection<Customers>();
