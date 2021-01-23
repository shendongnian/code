     class ListViewItemComparer : IComparer
     {
        private int col = 0;
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
     }
     class MyForm : Form
     {
        // private System.Windows.Forms.ListView listView1;
        // ColumnClick event handler.
        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
     }
