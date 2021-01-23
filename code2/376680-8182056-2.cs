        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listView1.FocusedItem != null)
            {
                if (listView1.FocusedItem.ImageIndex == 1)
                {
                    listView1.FocusedItem.ImageIndex = 0;
                    m_CheckedItems.Remove(listView1.FocusedItem);
                }
                else
                {
                    listView1.FocusedItem.ImageIndex = 1;
                    m_CheckedItems.Add(listView1.FocusedItem);
                }
            }
        }
