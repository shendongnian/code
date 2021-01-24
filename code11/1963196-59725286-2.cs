c#
class CountryWithDates
{
    //Following the naming rule is good. I'll leave it to you.
    public string country { get; set; }
    public DateTime firstDate { get; set; }
    public DateTime furtherDate { get; set; }
    public DateTime rolldownDate { get; set; }
    public DateTime endDate { get; set; }
    public CountryWithDates() { }
    public override string ToString()
    {
        return country;
    }
}
This way you can bind a list of `CountryWithDates` objects to the `CheckedListBox`:
c#
var lst = new List<CountryWithDates>();
//Add new objects ...
//lst.Add(new CountryWithDates { country = "Country 1", firstDate ... });
checkedListBox1.DataSource = null;
checkedListBox1.DataSource = lst;
To get and update the checked items from the list, create a new `BindingSource`, and bind it to the `DataGridView`, you just need to do:
c#
checkedListBox1.CheckedItems
    .Cast<CountryWithDates>()
    .ToList()
    .ForEach(item =>
    {
        item.firstDate = firstDatePicker.Value;
        item.furtherDate = furtherDatePicker.Value;
        item.rolldownDate = rolldownDatePicker.Value;
        item.endDate = endMarkdownPicker.Value;
    });
dataGridView1.DataSource = null;
var bs = new BindingSource(checkedListBox1.CheckedItems.Cast<CountryWithDates>(), null);
dataGridView1.DataSource = bs;
