`  void sort()
        {
            if (listBox1.Items.Count <= 1)
                return;
            for (int i = 0; i < listBox1.Items.Count - 2; i++)
            {
                listBox1.SetSelected(i, true);
                string a = listBox1.SelectedItem.ToString();
                listBox1.SetSelected(++i, true);
                i--;
                string b = listBox1.SelectedItem.ToString();
                if (b.CompareTo(b) == 1)
                {
                    listBox1.Items.RemoveAt(i);
                    listBox1.Items.Insert(i, b);
                    i++;
                    listBox1.Items.RemoveAt(i);
                    listBox1.Items.Insert(i, a);
                    i--;
                }
            }
        }`
