`
public IWebElement FindCellByText(string pText)
{
    return Cells.SelectMany(m => m.Value).FirstOrDefault(e=> e.Text == pText));
}
