     private void SwapListView(ListView list, ListViewItem itemA, ListViewItem itemB)
     {
            int bIndex = itemB.Index;
            int aIndex = itemA.Index;
            list.Items.Remove(itemB);
            list.Items.Remove(itemA);
            list.Items.Insert(bIndex, itemA);
            list.Items.Insert(aIndex, itemB);
     }
