var pivotItems = filterField.PivotItems();
DateTime date = Convert.ToDateTime(item.Name);
foreach (var item in pivotItems)
{
    item.Visible = false;
    if (date < DateTime.Now.AddDays(-30) || date > DateTime.Now.AddDays(-20))
    {
        item.Visible = true;
    }
}
