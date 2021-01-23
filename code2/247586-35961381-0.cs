    class SimpleDataGridView : DataGridView {
        public Action<DataGridViewCellMouseEventArgs> BeforeCellMouseDown;
        public Action<DataGridViewCellMouseEventArgs> AfterCellMouseDown;
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e) {
            if(BeforeCellMouseDown != null)
                BeforeCellMouseDown(e);
            base.OnCellMouseDown(e);
            if(AfterCellMouseDown != null)
                AfterCellMouseDown(e);
        }
    }
