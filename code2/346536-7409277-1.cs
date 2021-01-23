    public GridColorSetter : IChain
    {
     public IChain NextHandler(get;set;)
    public void ProcessEvent(object sender, DataGridViewCellEventArgs e)
    {
           if (datagridview_CustomerList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == ColumnNames.NewRateColumn.ToString())
            {
                var row = datagridview_CustomerList.Rows[e.RowIndex];
                var font = datagridview_CustomerList.Font;
    
                if (modMain.SSS_ToDecimal(row.Cells[ColumnNames.NewRateColumn.ToString()].Value) > 0)
                {
                    row.DefaultCellStyle.Font = new Font(font, FontStyle.Regular);
                    if (modMain.SSS_ToDecimal(row.Cells[ColumnNames.BudgetBalanceColumn.ToString()].Value) > 0)
                        row.DefaultCellStyle.BackColor = color_BudgetCustomers;
                    else
                        row.DefaultCellStyle.BackColor = color_OriginalColor;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = color_ZeroCharge;
                    row.DefaultCellStyle.Font = new Font(font, FontStyle.Strikeout);
                }
            }
    
        if (this.NextHandler!= null)
          this.NextHandler.ProcessEvent;
    
     }
    }
    }
   
