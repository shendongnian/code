    private void button1_Click(object sender, EventArgs e)
    {
       Thread t = new Thread(new ThreadStart(Display));
       t.Start();
    }
    private void Display()
    {
       for(int i = 0; i < 8; i++)
       {
          label1.Text = NameList[r.Next(5)];
          Thread.Sleep(1000);
       }
    }
