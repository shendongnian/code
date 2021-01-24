    public class MyForm : Form
    {
        private RabbitMQManager _rabbitMQManager;
        public MyForm() { _rabbitMQManager = new RabbitMQManager(); }
        // you can call this from constructor or some event
        public void Connect()
        {
            _rabbitMQManager.MessageReceived = (sender, msg) => someLabel.Text = msg;
            _rabbitMQManager.Connect();
        }
    }
