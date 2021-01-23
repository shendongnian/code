        private string[] GetListViewItemColumns(ListViewItem item) {
            var columns = new string[item.SubItems.Count];
            for (int column = 0; column < columns.Length; column++) {
                columns[column] = item.SubItems[column].Text;
            }
            return columns;
        }
