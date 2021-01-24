    using System.Windows.Forms;
    public class MyDataGridViewButtonColumn : DataGridViewButtonColumn
    {
        public event EventHandler<DataGridViewCellEventArgs> ContentClick;
        public void RaiseContentClick(DataGridViewCellEventArgs e)
        {
            ContentClick?.Invoke(DataGridView, e);
        }
        public MyDataGridViewButtonColumn()
        {
            CellTemplate = new MyDataGridViewButtonCell();
        }
    }
    public class MyDataGridViewButtonCell : DataGridViewButtonCell
    {
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            var column = this.OwningColumn as MyDataGridViewButtonColumn;
            column?.RaiseContentClick(e);
            base.OnContentClick(e);
        }
    }
