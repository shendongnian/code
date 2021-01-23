        public Form1()
        {
            InitializeComponent();
        }
        public event EventHandler Button1Clicked;
        public void Update(string data)
        {
            this.label1.Text = data;
        }
        private void Button1Click(object sender, EventArgs e)
        {
            if (this.Button1Clicked != null)
            {
                this.Button1Clicked(this, EventArgs.Empty);
            }
        }
