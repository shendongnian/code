        ...............
        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }        
        private void MyFunc(EventHandler Meth)
        {
            button1.Click += Meth;
        }
        private void TestCall()
        {
            MyFunc(btn_Click);
        }
        ............
