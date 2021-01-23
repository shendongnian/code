    using System;
    using System.ServiceModel;
    
    namespace WPFServiceHost1.Service
    {
        [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
        public class ClientService : IClientService
        {
            private MainWindow _MainWindow;
    
            public ClientService(MainWindow window)
            {
                _MainWindow = window;
            }
    
            #region IClientService Members
            public void ClientNotification(string message)
            {
                try
                {
                    _MainWindow._SyncContext.Send(state =>
                    {
                        _MainWindow.listBox1.Items.Add(message);
                    }, null);
                }
                catch (Exception ex)
                {
                    throw new FaultException(ex.Message);
                }
            }
            #endregion
        }
    }
