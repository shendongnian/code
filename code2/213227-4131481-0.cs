     for (int i = 0; i < listView1.Items.Count; i++)
         {
            for (int j = 0; j < listView1.Columns.Count; j++)
            {
                richTextBox1.Text += listView1.Items[i].SubItems[j].Text.ToString()+"\t";
            }
            richTextBox1.Text += "\n";
                                
          }
