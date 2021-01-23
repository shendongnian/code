        public Form2()
        {
            InitializeComponent();
           
            ArrayList paths = new ArrayList();
            paths.Add("path1");
            paths.Add("path2");
            paths.Add("path3");
            paths.Add("path4");
            foreach (string test in paths)
            {
                listBox1.Items.Add(test);
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = listBox1.SelectedItem.ToString();
        }
