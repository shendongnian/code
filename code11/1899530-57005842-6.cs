     protected async override void OnNavigatedTo(NavigationEventArgs e)
     {
         base.OnNavigatedTo(e);
    
         if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
         {
             App.AppServiceConnected += MainPage_AppServiceConnected;
             App.AppServiceDisconnected += MainPage_AppServiceDisconnected;
             await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
         }
     }
    
     private async void MainPage_AppServiceDisconnected(object sender, EventArgs e)
     {
         await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
         {
             Reconnect();
         });
     }
    
     
    private void MainPage_AppServiceConnected(object sender, AppServiceTriggerDetails e)
     {
         App.Connection.RequestReceived += AppServiceConnection_RequestReceived;
    
     }
     private async void AppServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
     {
         string value = args.Request.Message["OK"] as string;
         await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
          {
              InfoBlock.Text = value;
          });
    
    
     }     
     private async void Reconnect()
     {
         if (App.IsForeground)
         {
             MessageDialog dlg = new MessageDialog("Connection to desktop process lost. Reconnect?");
             UICommand yesCommand = new UICommand("Yes", async (r) =>
             {
                 await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
             });
             dlg.Commands.Add(yesCommand);
             UICommand noCommand = new UICommand("No", (r) => { });
             dlg.Commands.Add(noCommand);
             await dlg.ShowAsync();
         }
     }
     private int count = 0;
     private async void SendMesssage(object sender, RoutedEventArgs e)
     {
         count++;
         ValueSet request = new ValueSet();
         request.Add("KEY", $"Test{count}");
         AppServiceResponse response = await App.Connection.SendMessageAsync(request);
    
         // display the response key/value pairs
    
         foreach (string value in response.Message.Values)
         {
             await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
             {
                 StatusBlock.Text = value;
             });
    
         }
     }
