    void recalculateTotalExpression()
    {
       // 0. Create a StringBuilder for your new Expression.
       // 1. Go through each of the columns of your datagridview, except the TotalColumn
       // 2. Foreach Visible DataGridView Column, add the corresponding DataTable column to the expression.
       // 3. Set the Expression to the TotalColumn : TotalColumn.Expression = sb.toString();
    }
    
    void MyDataGridView_OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
    {
       recalculateTotalExpression();
    }
