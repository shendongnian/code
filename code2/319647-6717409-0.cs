    SerialPort spWeigh;
    string strResponseWeigh;
    private delegate void SetTextDeleg(string text);
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
    }
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        spWeigh = new SerialPort("COM1", 2400, Parity.None, 8, StopBits.One);
        spWeigh.RtsEnable = false;
        spWeigh.DtrEnable = false;
        spWeigh.Handshake = Handshake.None;
        spWeigh.ReadTimeout = 10000; 
        spWeigh.DataReceived += spWeigh_DataInReceived;
        spWeigh.Open();
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        spWeigh.Write("W"); 
    }
    void spWeigh_DataInReceived(object sender, SerialDataReceivedEventArgs e)
    {
        strResponseWeigh = spWeigh.ReadLine();
        string wt = strResponseWeigh.Substring(5, 7);
        this.TxtFrstWt.Dispatcher.BeginInvoke(new SetTextDeleg(sin_DataReceived), new object[] { wt });
    }
    private void sin_DataReceived(string data)
    {
        TxtFrstWt.Text = data.Trim();
        TxtDateIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
    }
