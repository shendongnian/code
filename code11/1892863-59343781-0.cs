    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        void Print(string message)
        {
            this.Invoke(new Action(() => { listBox1.Items.Add(message); }));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 55555));
            byte[] vs = new byte[100];
            EndPoint senderRemote = new IPEndPoint(IPAddress.Any, 0);
            Dictionary<EndPoint, int> pairs = new Dictionary<EndPoint, int>();
            int id = 0;
            for (int ii = 0; ii < 5; ii++)
            {
                socket.ReceiveFrom(vs, ref senderRemote);
                if (pairs.ContainsKey(senderRemote))
                    Print(pairs[senderRemote].ToString() + " says:");
                else
                {
                    pairs.Add(senderRemote, id++);
                    Print("new sender");
                }
                Print(senderRemote.ToString());
                Print(Encoding.Unicode.GetString(vs));
                socket.SendTo(vs, senderRemote);
            }
        }
    }
client:
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        Socket socket;
        private void button1_Click(object sender, EventArgs e)
        {
            socket.Send(Encoding.Unicode.GetBytes("Gholamam!"));
            byte[] vs = new byte[100];
            socket.Receive(vs);
            listBox1.Items.Add(Encoding.Unicode.GetString(vs));
        }
        private void Client_Load(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, new Random().Next(1024,65000)));
            socket.Connect(IPAddress.Loopback, 55555);
        }
    }
don't forget that client and server are communicating. therefore they must use compromised way to communicate. if you like to store client information, it must be constant. for this, you must `bind` it to a fixed `localEndPoint`.
<br>you can also use the solution in the question comments: you can add an id in messages. also you can use both.
<br>P.S.: I'm using `Socket` Class instead of `TCPClient` or `UDPClient` because i found them awkward and inconsistent in some manners.
