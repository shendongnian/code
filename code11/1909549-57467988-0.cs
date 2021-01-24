    public class DataGridViewWithFormatting : System.Windows.Forms.DataGridView
    {
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            var myE = new MyDataGridViewCellEventArgs(e);
            base.OnCellMouseEnter(myE);
            if (!myE.Cancel)
                this.Cursor = Cursors.Default;
        }
    }
    public class MyDataGridViewCellEventArgs : DataGridViewCellEventArgs
    {
        public bool Cancel { get; set; } = false;
        public MyDataGridViewCellEventArgs(DataGridViewCellEventArgs e)
            : base(e.ColumnIndex, e.RowIndex) { }
    }
