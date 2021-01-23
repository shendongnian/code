        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.AllowDrop = true;
            listView1.DragDrop += new DragEventHandler(listView1_DragDrop);
            listView1.DragEnter += new DragEventHandler(listView1_DragEnter);
        }
        void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        void listView1_DragDrop(object sender, DragEventArgs e)
        {
            listView1.Items.Add(e.Data.ToString());
        }
