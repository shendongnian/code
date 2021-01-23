    private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
            {
                if (e.IsAvailable)
                    Console.WriteLine("Wi-Fi conectado " + DateTime.Now );
                else
                    Console.WriteLine("Wi-Fi desconectado " + DateTime.Now);
            }
    
    
            public Inicio()
            {
                InitializeComponent();
    
                NetworkAvailabilityChangedEventHandler myHandler = new NetworkAvailabilityChangedEventHandler(AvailabilityChanged);
                NetworkChange.NetworkAvailabilityChanged += myHandler;
            }
