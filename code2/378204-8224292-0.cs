    dataView.CellFormatting += (s, e) =>
    {
        if ((e.ColumnIndex == 1) && ((dataView.SelectedCells.Count == 1)))
        {
            var scope = Scope.Instance;
            var row = dataView.Rows[e.RowIndex];
            var variable = row.DataBoundItem as Variable;
    
            if (scope.Variables.Contains(variable))
            {
                dataView[e.ColumnIndex, e.RowIndex].Style.BackColor =
                    scope.GetGraph(variable).Color;
            }
    
            else
            {
                dataView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }
    };
