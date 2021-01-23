    private void button1_Click(object sender, EventArgs e)
      {
           foreach (var item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(item);
            }
            for (int s = 0; s < listBox1.Items.Count; s++)
            {
                for (int t = 0; t < listBox2.Items.Count; t++)
                {
                    if (listBox1.Items[s].ToString().Equals(listBox2.Items[t].ToString()))
                    {
                        listBox1.Items.RemoveAt(s);
                    }
                }
            }
      }
