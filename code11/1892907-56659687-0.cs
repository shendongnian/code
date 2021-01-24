var startDate = DateTime.Now.Date;
var numberOfDays = startDate.Subtract(startDate.AddMonths(-1)).Days;
for(int i = 0; i <= numberOfDays; i++)
{
    ListItem li = new ListItem(DateTime.Now.AddDays(-1*i).ToString("MMM/dd"), DateTime.Now.AddDays(-1*i).ToString("MMM/dd"));
    DropDownList1.Items.Add(li);
    DropDownList2.Items.Add(li);
}
