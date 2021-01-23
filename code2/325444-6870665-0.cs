    OnItemDataBound="Expenses_ItemDataBound"
    protected void Expenses_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            
            Label ExpenseTypeLabel = (Label)e.Item.FindControl("ExpenseTypeLabel");
            string ExpenseType = (ExpenseTypeLabel.Text.ToString());
            if (ExpenseType == "Mileage")
            {
                // disable button
            }
        }
    }
