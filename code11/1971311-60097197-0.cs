List<DayOfWeek> result = null;
if (rbDaily.Checked || rbTwoWeeks.Checked)
{
    result = new List<DayOfWeek>();
    if (checkboxMon.Checked)
        result.Add(DayOfWeek.Monday);
    if (checkboxWed.Checked)
        result.Add(DayOfWeek.Wednesday);
}
If you have lots of different checkboxes for different days of the week, you can do something like:
var checkboxes = new List<(Checkbox checkbox, DayOfWeek dow)>()
{
    (checkboxMon, DayOfWeek.Monday),
    ... etc ...
};
var result = (rbDaily.Checked || rbTwoWeeks.Checked)
    ? checkboxes.Where(x => x.checkbox.Checked).Select(x => x.dow).ToList()
    : null;
