        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(k => {
                    textBox2.Invoke(new Action(() => {
                        textBox2.AppendText("k:" + k + "\r\n");
                    }));
                } , i);
            }
        }
