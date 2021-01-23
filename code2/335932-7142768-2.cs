        public partial class FirstDataKindReceivingForm :
            System.Windows.Forms.Form,
            IExchangeDataReceiver
        {
            // usual form stuff
            // ...
            private IExchangeDataProvider myDataProvider;
            public void ConnectDataProvider(IExchangeDataProvider Provider)
            {
                myDataProvider = Provider;
                myDataProvider.FirstDataKindReceived += 
                    new EventHandler<FirstDataKindEventArgs>(
                        HandleFirstKindOfDataReceived
                    );
            }
 
            private void HandleFirstKindOfDataRecieved (
                object sender, FirstDataKindEventArgs
            )
            {
                // do whatever with data
            }
        }
        #endregion
    }
