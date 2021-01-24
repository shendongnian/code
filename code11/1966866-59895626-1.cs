        private bool needSave;
        private object locker = new object();
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText("test.txt");
            timer1.Interval = 5000;
            timer1.Enabled = true;
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (needSave)
            {
                needSave = false;
                await Task.Run(() => Save());
            }
        }
        private void Save()
        {
            lock (locker)
            {
                File.WriteAllText("test.txt", textBox1.Text);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }
