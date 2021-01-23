            private void Form1_Load(object sender, EventArgs e)
        {
            List<IMyBindingObject> obj = new List<IMyBindingObject>();
            obj.Add(new MyObject("Test A", "Test B", "Test C"));
            obj.Add(new MyObject("T A", "T B", "T C"));
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = obj;
        }
