    using System;
    using System.ServiceModel;
    namespace WPFServiceHost1.Service
    {
        public class ClientServiceHost : IDisposable
        {
            private bool _Initalized;
    
            private ServiceHost _InnerServiceHost;
            private MainWindow _MainWindow;
    
            public ClientServiceHost(MainWindow mainWindow)
            {
                _MainWindow = mainWindow;
                InitializeServiceHost();
            }
            private void InitializeServiceHost()
            {
                try
                {
                    ClientService clientService = new ClientService(_MainWindow);
                    _InnerServiceHost = new ServiceHost(clientService);
    
                    _InnerServiceHost.Opened += new EventHandler(_InnerServiceHost_Opened);
                    _InnerServiceHost.Faulted += new EventHandler(_InnerServiceHost_Faulted);
                    _InnerServiceHost.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to initialize ClientServiceHost", ex);
                }
            }
    
            void _InnerServiceHost_Opened(object sender, EventArgs e)
            {
                _Initalized = true;
            }
    
            void _InnerServiceHost_Faulted(object sender, EventArgs e)
            {
                this._InnerServiceHost.Abort();
    
                if (_Initalized)
                {
                    _Initalized = false;
                    InitializeServiceHost();
                }
            }
    
            #region IDisposable Members
    
            public void Dispose()
            {
                try
                {
                    _InnerServiceHost.Opened -= _InnerServiceHost_Opened;
                    _InnerServiceHost.Faulted -= _InnerServiceHost_Faulted;
                    _InnerServiceHost.Close();
                }
                catch
                {
                    try { _InnerServiceHost.Abort(); }
                    catch { }
                }
            }
            #endregion
        }
    }
