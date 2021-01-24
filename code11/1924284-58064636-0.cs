       TextBox[] txtbox;
      
        public FormOne()
        {
            InitializeComponent();
          
         
            Sqlconn con = new Sqlconn();
            txtbox = new TextBox[] { txtBox1, txtBox2, txtBox3, txtBox4, txtBox5, txtBox6, txtBox7};
            foreach (TextBox text in txtbox)
                text.TextChanged += new EventHandler(txtbox_TextChanged);
           }
           private void txtbox_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            int total = 0;
            foreach (TextBox text in txtbox)
            {
                if (int.TryParse(text.Text, out value))
                    total += value;
            }
            txtBox7.Text = total.ToString();
            txtBox8.Text = total.ToString();
            private void FormOne_Load(object sender, EventArgs e)
            {
            }
