        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < this.listView.Columns.Count - 1;i++ ) this.listView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);           
            this.listView.Columns[this.listView.Columns.Count - 1].Width = -2;
        }
