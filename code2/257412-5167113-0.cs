    void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                dataGridBoatCompanyList.ItemsSource =
                    new ObservableCollection<ReterivedEmailData>(new[]
                                                                     {
                                                                         new ReterivedEmailData
                                                                             {Email = "dfsd", Name = "fadsfds"}
                                                                     });
            }
