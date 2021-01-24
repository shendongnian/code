        public Form1()
        {
            InitializeComponent();         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000);
                    label2.Text = i.ToString();
                }
            });
            Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000);
                    label3.Text = i.ToString();
                }
            });
        } 
    }
