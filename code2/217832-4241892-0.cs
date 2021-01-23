    private void InitilizeDataGridView(DataGridView view)
    {
        var defaultCellStyle = new DataGridViewCellStyle();
        defaultCellStyle.ForeColor = SystemColors.ControlText;
        defaultCellStyle.WrapMode = DataGridViewTriState.False;
        defaultCellStyle.SelectionBackColor = SystemColors.Highlight;
        defaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
        defaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
        defaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        defaultCellStyle.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((0)));
        view.DefaultCellStyle = defaultCellStyle;
        view.MultiSelect = false;
        view.RowHeadersVisible = false;
        view.AllowUserToAddRows = false;
        view.ColumnHeadersVisible = false;
        view.AllowUserToResizeRows = false;
        view.AllowUserToDeleteRows = false;
        view.AllowUserToOrderColumns = true;
        view.AllowUserToResizeColumns = false;
        view.BackgroundColor = SystemColors.Control;
        for(var i = 0; i < 16; i++)
        {              
            view.Columns.Add(new DataGridViewTextBoxColumn { AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Resizable = DataGridViewTriState.False });
        }
        DataGridViewRow row = null;
        for (int index = 32, cell = 0; index < 255; index++, cell++)
        {
            if(cell % 16 == 0)
            {
                if(row != null)
                {
                    view.Rows.Add(row);
                }
                row = new DataGridViewRow { Height = 40 };
                row.CreateCells(view);
                
                cell = 0;
            }
            if (row != null)
            {
                row.Cells[cell].Value = Char.ConvertFromUtf32(index);
            }               
        }            
    }
