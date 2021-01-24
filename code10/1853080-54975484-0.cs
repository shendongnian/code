    private ManualResetEvent manualReset = new ManualResetEvent(false);
    
    void test()
    {
        using (var ws = new WebSocket("wss://stream.binance.com:9443/ws/bnbbtc@ticker"))
        {
            ws.OnMessage += (sender, e) =>
             Invoke((System.Windows.Forms.MethodInvoker)delegate { richTextBox1.Text = "Message: " + e.Data; });
    
            ws.OnError += (sender, e) =>
                Invoke((System.Windows.Forms.MethodInvoker)delegate { richTextBox1.Text = "Error: " + e.Message; });
    
            ws.Connect();
    		
    		manualReset.WaitOne();
        }
    }
    
    void signalExit()
    {
    	manualReset.Set();
    }
