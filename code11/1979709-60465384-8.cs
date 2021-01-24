    class Game
    {
        private System.Threading.Timer deliveryTimer = null;
        private int counter;
        public event EventHandler DeliveryProgressChangedEvent;
        public event EventHandler DeliveryCompletedEvent;
        public Game(int eventsCount) { counter = eventsCount; }
        public void StartDelivery()
        {
            deliveryTimer = new System.Threading.Timer(MakeDelivery);
            deliveryTimer.Change(1000, 1000);
        }
        public void StopDelivery() => deliveryTimer?.Dispose();
        private void MakeDelivery(object state)
        {
            DeliveryProgressChangedEvent?.Invoke(this, EventArgs.Empty);
            counter -= 1;
            if (counter == 0) {
                deliveryTimer?.Dispose();
                DeliveryCompletedEvent?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public partial class Form1 : Form
    {
        Game game = null;
        public Form1()
        {
            InitializeComponent();
            pbDelivery.Maximum = 5;
            game = new Game(pbDelivery.Maximum);
            game.DeliveryProgressChangedEvent += onDeliveryProgressChanged;
            game.DeliveryCompletedEvent += onDeliveryCompleted;
        }
        private void onDeliveryProgressChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => {
                pbDelivery.Increment(1);
                MessageBox.Show(this, "Delivery In progress");
            }));
        }
        private void onDeliveryCompleted(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => MessageBox.Show(this, "Delivery Completed")));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            game.StartDelivery();
        }
    }
