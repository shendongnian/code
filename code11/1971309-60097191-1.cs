cs
? new List<DayOfWeek?>
              { 
                  checkboxMon.Checked ? DayOfWeek.Monday : (DayOfWeek?)null, checkboxWed.Checked ? DayOfWeek.Wednesday : (DayOfWeek?)null
              }
              : null;
Or even get rid of the conditional operator and use something like that
cs
if (rbDaily.Checked || rbTwoWeeks.Checked)
{
    var list = new List<DayOfWeek>();
    if (checkboxMon.Checked)
        list.Add(DayOfWeek.Monday);
    if (checkboxWed.Checked)
        list.Add(DayOfWeek.Wednesday);
}
