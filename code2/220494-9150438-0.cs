    using System;
    using System.Drawing;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;
    class AsyncTcpClient Form:
    {
    private TextBox newText;
    private TextBox conStatus;
    private ListBox results;
    private Socket client;
    private byte[] data = new byte[1024];
    private int size = 1024;
    public AsyncTcpClient()
    {
    Text = "Asynchronous TCP Client";
    Size = new Size(400, 380);
    Label label1 = new Label();
    label1.Parent = this;
    label1.Text = "Enter text string:";
    label1.AutoSize = true;
    label1.Location = new Point(10, 30);
    newText = new TextBox();
    newText.Parent = this;
    newText.Size = new Size(200, 2 * Font.Height);
    newText.Location = new Point(10, 55);
    results = new ListBox();
    results.Parent = this;
    results.Location = new Point(10, 85);
    results.Size = new Size(360, 18 * Font.Height);
    Label label2 = new Label();
    label2.Parent = this;
    label2.Text = "Connection Status:";
    label2.AutoSize = true;
    label2.Location = new Point(10, 330);
    conStatus = new TextBox();
    conStatus.Parent = this;
    conStatus.Text = "Disconnected";
    conStatus.Size = new Size(200, 2 * Font.Height);
    conStatus.Location = new Point(110, 325);
    This document is created with the unregistered version of CHM2PDF Pilot
    Button sendit = new Button();
    sendit.Parent = this;
    sendit.Text = "Send";
    sendit.Location = new Point(220,52);
    sendit.Size = new Size(5 * Font.Height, 2 * Font.Height);
    sendit.Click += new EventHandler(ButtonSendOnClick);
    Button connect = new Button();
    connect.Parent = this;
    connect.Text = "Connect";
    connect.Location = new Point(295, 20);
    connect.Size = new Size(6 * Font.Height, 2 * Font.Height);
    connect.Click += new EventHandler(ButtonConnectOnClick);
    Button discon = new Button();
    discon.Parent = this;
    discon.Text = "Disconnect";
    discon.Location = new Point(295,52);
    discon.Size = new Size(6 * Font.Height, 2 * Font.Height);
    discon.Click += new EventHandler(ButtonDisconOnClick);
    }
    void ButtonConnectOnClick(object obj, EventArgs ea)
    {
    conStatus.Text = "Connecting...";
    Socket newsock = new Socket(AddressFamily.InterNetwork,
    SocketType.Stream, ProtocolType.Tcp);
    IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
    newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);
    }
    void ButtonSendOnClick(object obj, EventArgs ea)
    {
    byte[] message = Encoding.ASCII.GetBytes(newText.Text);
    newText.Clear();
    client.BeginSend(message, 0, message.Length, SocketFlags.None,
    new AsyncCallback(SendData), client);
    }
    void ButtonDisconOnClick(object obj, EventArgs ea)
    {
    client.Close();
    conStatus.Text = "Disconnected";
    }
    void Connected(IAsyncResult iar)
    {
    client = (Socket)iar.AsyncState;
    try
    {
    client.EndConnect(iar);
    conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
    client.BeginReceive(data, 0, size, SocketFlags.None,
    new AsyncCallback(ReceiveData), client);
    } catch (SocketException)
    {
    conStatus.Text = "Error connecting";
    }
    }
    void ReceiveData(IAsyncResult iar)
    {
    Socket remote = (Socket)iar.AsyncState;
    int recv = remote.EndReceive(iar);
    string stringData = Encoding.ASCII.GetString(data, 0, recv);
    results.Items.Add(stringData);
    }
    void SendData(IAsyncResult iar)
    {
    Socket remote = (Socket)iar.AsyncState;
    int sent = remote.EndSend(iar);
    remote.BeginReceive(data, 0, size, SocketFlags.None,
    This document is created with the unregistered version of CHM2PDF Pilot
    new AsyncCallback(ReceiveData), remote);
    }
    public static void Main()
    {
    Application.Run(new AsyncTcpClient());
    }
    }
