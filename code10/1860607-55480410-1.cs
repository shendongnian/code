    public partial class ConnectView : ContentPage
    {
        public IConnections Conectado;
    
        public ConnectView ()
        {
          InitializeComponent ();
    
            Conectado = DependencyService.Get<IConnections>();
            BindingContext = App.CVM;
            MACS_Disponiveis.ItemsSource = App.CVM.BLE_Devices;
            Protocol_Disponivel.ItemsSource = App.SVM.Saved_Protocols;
    
            if (App.SVM.Saved_Protocols.Count > 0)
                ProtoScreen.IsVisible = true;
    
            Status_recebimento.MaxLines=1;
        }
    //.
    //.
    //.
    }
    
