    public class DataGridViewWithFormatting : System.Windows.Forms.DataGridView
    {
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            var myE = new MyDataGridViewCellEventArgs(e);
            base.OnCellMouseEnter(myE);
            if (!myE.Handled)
                this.Cursor = Cursors.Default;
        }
    }
    public class MyDataGridViewCellEventArgs : DataGridViewCellEventArgs
    {
        public bool Handled { get; set; } = false;
        public MyDataGridViewCellEventArgs(DataGridViewCellEventArgs e)
            : base(e.ColumnIndex, e.RowIndex) { }
    }
