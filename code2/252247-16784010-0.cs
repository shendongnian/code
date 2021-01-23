	private: void Swapinlistbox( int indexA, int indexB)
            {
				ListViewItem item = listView1.Items[indexA];
				listView1.Items.Remove(item);
				listView1.Items.Insert(indexB, item);
            }
