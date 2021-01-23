    public delegate void UpdateTextCallback(string message);
    private void TestThread()
    {
        for (int i = 0; i <= 1000000000; i++)
        {
            Thread.Sleep(1000);                
            textBox1.Dispatcher.Invoke(
                new UpdateTextCallback(this.UpdateText),
                new object[] { i.ToString() }
            );
        }
    }
    private void UpdateText(string message)
    {
        richTextBox1.AppendText(message + "\n");
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
       Thread test = new Thread(new ThreadStart(TestThread));
       test.Start();
    }
