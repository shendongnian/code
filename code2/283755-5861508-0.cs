    protected override void InitializeRow(GridViewRow row, DataControlField[] fields)
       {
          base.InitializeRow(row, fields);
          foreach (DataControlFieldCell cell in row.Cells)
          {
             if (cell.Controls.Count > 0)
             {
                AddChangedHandlers(cell.Controls);
             }
          }
       }
