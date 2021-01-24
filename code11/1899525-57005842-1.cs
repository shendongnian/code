    private AppServiceConnection connection = null;
    public MainWindow()
    {
        InitializeComponent();
        InitializeAppServiceConnection();
    }
    private async void InitializeAppServiceConnection()
    {
        connection = new AppServiceConnection();
        connection.AppServiceName = "SampleInteropService";
        connection.PackageFamilyName = Package.Current.Id.FamilyName;
        connection.RequestReceived += Connection_RequestReceived;
        connection.ServiceClosed += Connection_ServiceClosed;
    
        AppServiceConnectionStatus status = await connection.OpenAsync();
        if (status != AppServiceConnectionStatus.Success)
        {
            MessageBox.Show(status.ToString());
            this.IsEnabled = false;
        }
    }
    
    private void Connection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
    {
        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            Application.Current.Shutdown();
        }));
    }
    
    private async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
    {
        // retrive the reg key name from the ValueSet in the request
        string key = args.Request.Message["KEY"] as string;
    
        if (key.Length > 0)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                InfoBlock.Text = key;
    
            }));
            ValueSet response = new ValueSet();
            response.Add("OK", "SEND SUCCESS");
            await args.Request.SendResponseAsync(response);
        }
        else
        {
            ValueSet response = new ValueSet();
            response.Add("ERROR", "INVALID REQUEST");
            await args.Request.SendResponseAsync(response);
        }
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        ValueSet response = new ValueSet();
        response.Add("OK", "AlerWindow Message");
        await connection.SendMessageAsync(response);
    }
