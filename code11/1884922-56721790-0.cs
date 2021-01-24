    {
        
     protected void send_Click(object sender, EventArgs e)
        {
            var sm = new SubmitSm();
            sm.SourceAddress.Npi = JamaaTech.Smpp.Net.Lib.NumberingPlanIndicator.Unknown;
            sm.SourceAddress.Ton = JamaaTech.Smpp.Net.Lib.TypeOfNumber.Aphanumeric
            sm.DestinationAddress.Ton = JamaaTech.Smpp.Net.Lib.TypeOfNumber.International;
            sm.DestinationAddress.Npi = JamaaTech.Smpp.Net.Lib.NumberingPlanIndicator.Unknown;
            TextMessage msg = new TextMessage();
            msg.DestinationAddress ="123456789"; //Receipient number
            msg.Text = "test test";
            msg.RegisterDeliveryNotification = true; //I want delivery notification for this message
            SmppClient client = GetSmppClient();
            client.BeginSendMessage(msg, SendMessageCompleteCallback, client);
        }
        private void client_ConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            switch (e.CurrentState)
            {
                case SmppConnectionState.Closed:
                    e.ReconnectInteval = 60000; //Try to reconnect after 1 min
                    break;
                case SmppConnectionState.Connected:
                    break;
                case SmppConnectionState.Connecting:
                    break;
            }
        }
        private SmppClient GetSmppClient()
        {
            SmppClient client = new SmppClient();
            System.Threading.Thread.Sleep(9000);
            SmppConnectionProperties properties = client.Properties;
            properties.SystemID = "xxxxxx";
            properties.Password = "xxxxxx";
            properties.Port = 10000; //IP port to use
            properties.Host = "xx.xx.xx.xx"; //SMSC host name or IP Address
            properties.SystemType = "SMPP";
            properties.DefaultServiceType = "SMPP";
            properties.SourceAddress = "MYCOMPANY";
            properties.AddressNpi = NumberingPlanIndicator.Unknown;
            properties.AddressTon = TypeOfNumber.Aphanumeric;
            properties.DefaultEncoding = DataCoding.Latin1;
            client.AutoReconnectDelay = 3000;
            client.KeepAliveInterval = 15000;
            client.Start();
            System.Threading.Thread.Sleep(9000);
            return client;
        }
        private static void SendMessageCompleteCallback(IAsyncResult result)
        {
            try
            {
                SmppClient client = (SmppClient)result.AsyncState;
                client.EndSendMessage(result);
            }
            catch (Exception e)
            {
               
            }
        }
}
