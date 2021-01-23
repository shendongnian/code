    Using System;
    Using System.Windows.Forms;
    
    public class myDataGridView:DataGridView
        {
            protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
            {
                //base.OnCellMouseDown(e);
                this.Rows[e.RowIndex].Selected = !this.Rows[e.RowIndex].Selected;
            }
    
            protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
            {
                //base.OnCellMouseClick(e);
            }
        }
