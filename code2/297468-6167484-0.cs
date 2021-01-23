        private void Form1_Load(object sender, EventArgs e)
        {
            CreateWindow("child 1");
            CreateWindow("child 2");
        }
        private void CreateWindow(string name)
        {
            Form window = new Form();
            window.MdiParent = this;
            window.Text = name;
            window.Show();
            Form surrogate = new Form();
            surrogate.FormBorderStyle = FormBorderStyle.None;
            surrogate.Text = name;
            surrogate.Show(this);
            surrogate.Size = Size.Empty;
            surrogate.GotFocus += new EventHandler(surrogate_GotFocus);
            
            surrogate.Tag = window;
            window.Tag = surrogate;
        }
        void surrogate_GotFocus(object sender, EventArgs e)
        {
            Form surrogate = sender as Form;
            if (null != surrogate && null != surrogate.Tag)
            {
                Form target = surrogate.Tag as Form;
                target.Focus();
            }
        }
