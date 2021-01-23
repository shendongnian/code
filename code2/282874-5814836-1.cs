        private Student _student = new Student();
        public Form2(string id) {
            InitializeComponent();
            textBox1.Text = id;
        }
        public Student Student {
            get {
                return _student;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            _student.Id = Convert.ToInt32(textBox1.Text);
            this.Close();
        }
