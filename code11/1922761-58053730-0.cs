    public partial class Form1 : Form
    {
        private int register = 0;
        private readonly int port = 502;
        private readonly List<ModbusServer> servers = new List<ModbusServer>();
        private readonly List<ModbusClient> clients = new List<ModbusClient>();
        public Form1()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.FirstChanceException +=
                (sender, e) => MessageBox.Show(e.Exception.Message);
        }
        private void Foo(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
        private void Ser_HoldingRegistersChanged(int register, int numberOfRegisters) =>
            MessageBox.Show($"register: {register}, numberOfRegisters: {numberOfRegisters}");
        private void AddServer_Click(object sender, EventArgs e) =>
            AddServerMethod();
        private void AddClient_Click(object sender, EventArgs e) =>
            AddClientMethod();
        private void AddServerMethod()
        {
            var server = new ModbusServer { Port = port };
            server.Listen();
            server.HoldingRegistersChanged += Ser_HoldingRegistersChanged;
            servers.Add(server);
            MessageBox.Show("Server added.");
            server.holdingRegisters[0] = 11; // register is changed, but no event is fired
        }
        private void AddClientMethod()
        {
            var client = new ModbusClient("127.0.0.1", port);
            client.Connect();
            clients.Add(client);
            MessageBox.Show("Client added.");
            client.WriteSingleRegister(register++, 11); // event is fired
        }
    }
