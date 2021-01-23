        private void Form1_Load(object sender, EventArgs e)
        {
            //Added some dummy items
            for(int i=0; i<10; i++)
                listView1.Items.Add("Item"+i.ToString());
            //Disable the button
            button1.Enabled = false;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = (listView1.SelectedItems.Count > 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }
