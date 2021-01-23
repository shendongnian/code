    {
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort sp;
        private void Form1_Load(object sender, EventArgs e)
        {
            sp = new SerialPort("COM1", 19200, Parity.Space, 8, StopBits.One);
            sp.ParityReplace = 0;
            sp.ErrorReceived += new SerialErrorReceivedEventHandler(sp_SerialErrorReceivedEventHandler);          
            sp.ReadTimeout = 5;
            sp.ReadBufferSize = 256;
            sp.Open();
        }
        object msgsLock = new object();
        Queue<byte[]> msgs = new Queue<byte[]>();
        public void sp_SerialErrorReceivedEventHandler(Object sender, SerialErrorReceivedEventArgs e)
        {
            if (e.EventType == SerialError.RXParity)
            {
               byte[] buffer = new byte[256];            
               try
               {                   
                   int cnt = sp.Read(buffer, 0, 256);
                   byte[] msg = new byte[cnt];
                   Array.Copy(buffer, msg, cnt);
                   if (cnt > 0)
                   {
                       lock (msgsLock)
                       {
                           msgs.Enqueue(msg);
                       }
                   }
               }
               catch
               {
               }              
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (msgs.Count > 0)
            {
                lock (msgsLock)
                {
                    listBox1.Items.Insert(0, BitConverter.ToString(msgs.Dequeue()));
                }
            }
        }
    }
