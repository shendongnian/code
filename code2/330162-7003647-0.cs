    string str = "hello world"; 
    object str_lock = new object();
    
    private Thread test = newThread(new ParameterizedThreadStart(invariant_loop));
    
    private void Form1_Load(object sender, EventArgs e)
    {
        test.Start();
    }
    
    private void invariant_loop()
    {
        do
        {
            System.Threading.Thread.Sleep(1000);
            lock(str_lock) {
                Console.WriteLine(str);
            }
        }
        while (true);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        lock(str_lock) {
            str = maskedTextBox1.Text;
        }
    }
