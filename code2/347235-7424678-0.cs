    using System;
    using System.Windows.Controls;
    using System.Windows.Messaging;
    namespace ReceivingApplication
    {
      public partial class Receiver : UserControl
      {
        public Receiver()
        {
            InitializeComponent();
            LocalMessageReceiver messageReceiver =
                new LocalMessageReceiver("receiver",
                ReceiverNameScope.Global, LocalMessageReceiver.AnyDomain);
            messageReceiver.MessageReceived += messageReceiver_MessageReceived;
            try
            {
                messageReceiver.Listen();
            }
            catch (ListenFailedException)
            {
                output.Text = "Cannot receive messages." + Environment.NewLine +
                    "There is already a receiver with the name 'receiver'.";
            }
        }
        private void messageReceiver_MessageReceived(
            object sender, MessageReceivedEventArgs e)
        {
            e.Response = "response to " + e.Message;
            output.Text =
                "Message: " + e.Message + Environment.NewLine +
                "NameScope: " + e.NameScope + Environment.NewLine +
                "ReceiverName: " + e.ReceiverName + Environment.NewLine +
                "SenderDomain: " + e.SenderDomain + Environment.NewLine +
                "Response: " + e.Response;
        }
      }
    }
