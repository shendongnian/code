     foreach (ListItem itemA in LisyBox2.Items)
            {
                   for (int i = ListBox1.Items.Count - 1; i > -1; i--)
                {
                    {
                        if (ListBox1.Items[i].Text == itemA.Text)
                        {
                            ListBox1.Items.RemoveAt(i);
                        }
                    }
    
                }
            }
