if (bunifuDataGridView1.Rows.Count > 0)
{
    foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
    {
        // Compare the Product on each row, add a watch to this value to assist debugging
        var product = Convert.ToString(row.Cells[2].Value);
        if (product == bunifuTextBox11.Text) // consider rename bunfuTextBox11 to something meaningful, like 'ProductNameTextBox'
        {
            row.Cells[5].Value = Convert.ToString(Convert.ToInt32(bunifuTextBox10.Text) + Convert.ToInt32(row.Cells[5].Value)); // consider rename bunifuTextBox10 to something more meaningful like 'ProductQuantityTextBox'
            found = true;
            obj5.ProductName = Convert.ToString(row.Cells[2].Value);
            obj5.CostPricePerProduct = Convert.ToInt32(row.Cells[3].Value);
            obj5.SellingPricePerProduct = Convert.ToInt32(row.Cells[4].Value);
            obj5.Quantity= Convert.ToInt32(row.Cells[5].Value);
            obj5.ExpiraryDate = Convert.ToString(row.Cells[6].Value);
            obj5.ProductNumber = Convert.ToInt32(obj2.ProductNumber);
            obj5.Quantity = Convert.ToInt32(row.Cells[5].Value);
            //context.Entry.state=Entrystate.modified;
            // If your context has automatic change tracking enabled, this following line is not necessary
            // But you need to make sure you are setting the State on the correct object tracker instance by passing it in to the Entry method.
            context.Entry(obj5).State = EntryState.Modified;
            context.SaveChanges();
            inboundgoods();
            refreshcustomergrid();
        }
    }
    if (!found)
    {
        inboundgoods();
    }
}
else
{
    inboundgoods();
}
If you are not getting to the `found = true;` line of code during debugging then review your comparison logic, look for spelling and whitespace issues, you may want to change the comparison to something like this if your inputs or stored data might have blank spaces or inconsistent letter casing.
if (product.Trim().Equals(bunifuTextBox11.Text.Trim(), StringComparison.OrdinalIgnoreCase))
> Take the time to use meaningful names for your data entry field controls, it will make you code easier to read and understand, especially when you post code examples to forums like SO!  
