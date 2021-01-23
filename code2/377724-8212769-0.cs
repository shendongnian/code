      listView1.Alignment = ListViewAlignment.Default;
      if (listView1.SelectedItems.Count == 0)
        return;
      Point p = listView1.PointToClient(new Point(e.X, e.Y));
      ListViewItem MovetoNewPosition = listView1.GetItemAt(p.X, p.Y);
      if (MovetoNewPosition == null) return;
      ListViewItem DropToNewPosition = (e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)) as ListView.SelectedListViewItemCollection)[0];
      ListViewItem CloneToNew = (ListViewItem)DropToNewPosition.Clone();
      int index = MovetoNewPosition.Index;
      listView1.Items.Remove(DropToNewPosition);
      listView1.Items.Insert(index, CloneToNew);
      listView1.Alignment = ListViewAlignment.SnapToGrid;
