    class MainWindow : Window
    {
         public MainWindow()
         {
              Initialize();
              DataContext = new MainVM();
         }
         public void FindCustomerClick(object sender, RoutedEventArgs args)
         {
              CustomerListView clv = new CustomerListView();
              clv.DataContext = (DataContext as MainVM).FindCustomer(search.Text);
              clv.Show();
         }
    }
