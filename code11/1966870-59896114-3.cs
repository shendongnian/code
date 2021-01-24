    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.Text = File.ReadAllText("test.txt");
        timer1.Interval = 2000;
        timer1.Enabled = false;  //***********
    }
    private async void timer1_Tick(object sender, EventArgs e)
    { 
        timer1.Stop();   //***********
        await Task.Run(() => Save()); 
    }
    private void Save()
    {
        lock (this)     //***********
            File.WriteAllText("test.txt", textBox1.Text); 
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        timer1.Stop();     //*********** skip pending save and start again
        timer1.Start();    //***********
    }
