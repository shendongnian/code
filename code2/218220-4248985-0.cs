        TextBox tb1 = new TextBox();
        TextBox tb2 = new TextBox();
        public Form1()
        {
            InitializeComponent();
            tb1.Top = 100;
            tb2.Top = 100 + tb1.Height;
            tb1.TextChanged += new EventHandler(tb1_TextChanged);
            this.Controls.Add(tb1);
            this.Controls.Add(tb2);
        }
        void tb1_TextChanged(object sender, EventArgs e)
        {
            tb2.Text = tb1.Text;
        } 
