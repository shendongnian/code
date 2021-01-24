        ConcurrentQueue<byte> b_rcv_buffer = new ConcurrentQueue<byte>();
    
        private Timer timer2;
        
        public void InitTimer()
                {
                    timer2 = new System.Windows.Forms.Timer();
                    timer2.Tick += new EventHandler(timer2_Tick);
                    timer2.Interval = 1; // in miliseconds
                    timer2.Start();
                }
    
        private async void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
            {
                int bytes = serialPort1.BytesToRead;
                byte[] buf = new byte[bytes];
                serialPort1.Read(buf, 0, serialPort1.BytesToRead);
    
                for(int i = 0; i < buf.Length; i++)
                {
                    b_rcv_buffer.Enqueue(buf[i]); //Enqueue every received Byte in Concurrentqueue
                }
            }
    
    private async void timer2_Tick(object sender, EventArgs e)
            {
                if (b_rcv_buffer.Contains<byte>(0x00))
                {
                    byte[] array = b_rcv_buffer.ToArray();
    
                    richTextBox1_receive.Invoke(new Action(() =>
                    {
                        richTextBox1_receive.AppendText(BitConverter.ToString(array) + "\n");
                        //richTextBox1_receive.ScrollToCaret();
                    }));            
    
                    byte ignored;
    
                    while (b_rcv_buffer.TryDequeue(out ignored));
            }
