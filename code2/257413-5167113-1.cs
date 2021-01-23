    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
                dataGridBoatCompanyList.ItemsSource =
                    new ObservableCollection<RetrievedEmailData>(new[]
                                                                     {
                                                                         new RetrievedEmailData
                                                                             {Email = "dfsd", Name = "fadsfds"}
                                                                     });
            }
