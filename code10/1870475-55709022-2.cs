    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //Set the first textbox 
                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                //Set the second textbox
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }
