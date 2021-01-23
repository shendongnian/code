        for (int i = 0; i < listView1.Items.Count; i++)
        {
            if (listView1.Items[i].SubItems[0].Text == "A1")
            {
                listView1.Items.RemoveAt(i);
                i--; // Back counter up one
            }
        }
