    void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        try
        {
             var ser = new DataContractJsonSerializer(
                        typeof(ObservableCollection<UserLeaderboards>));
             var users = ser.ReadObject(e.Result)
                             as ObservableCollection<UserLeaderboards>;
             lstbLeaders.ItemsSource = users;
         }
         catch (Exception ex)
         {
             MessageBox.Show(ex.Message);
         }
    }
