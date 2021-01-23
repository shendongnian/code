    for (int i = 0; i < listView1.Items.Count; i++)
    {
         richTextBox1.Text += listView1.Items[i].SubItems[0].Text.ToString();
         richTextBox1.Text += "\t"+listView1.Items[i].SubItems[2].Text.ToString();
         richTextBox1.Text += "\n";                                    
    }
