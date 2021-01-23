        public Form2()
        {
            InitializeComponent();
        }
        public event Action ButtonClickAction;
        private void button1_Click(object sender, EventArgs e)
        {
            Action a = ButtonClickAction;
            if (a != null)
                a();
            this.Close();
        }
