    public Form1()
    {
       InitializeComponent();
       dataGridView1.CellPainting += new 
          DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
    }
    private void dataGridView1_CellPainting(object sender,
       System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
    {
       // Change 2 to be your checkbox column #
       if (this.dataGridView1.Columns[2].Index == e.ColumnIndex && e.RowIndex >= 0)
       {
          // If its read only, dont draw it
          if (dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly)
          {
             // You can change e.CellStyle.BackColor to Color.Gray for example
             using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
             {
                // Erase the cell.
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                e.Handled = true;
             }
          }
       }
    }
