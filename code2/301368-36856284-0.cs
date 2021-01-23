    > using System; using System.Collections.Generic; using System.Linq;
    > using System.Web; using System.Web.UI; using
    > System.Web.UI.WebControls;
    > 
    > namespace vbvb {
    >     public partial class _Default : Page
    >     {
    >         protected void Page_Load(object sender, EventArgs e)
    >         {
    >             if (!IsPostBack)
    >             {
    >                 DateTime today = DateTime.Today;
    >                 DateTime otherday = DateTime.Today.AddYears(1);
    > 
    >                 Calendar1.TodaysDate = today;
    >                 Calendar1.SelectedDate = Calendar1.TodaysDate;
    >                 Calendar2.TodaysDate = otherday;
    >                 Calendar2.SelectedDate = Calendar2.TodaysDate;
    > 
    >                 TextBox1.Text = Calendar1.SelectedDate.ToString("dd-MMM-yy");
    >                 TextBox2.Text = Calendar2.SelectedDate.ToString("dd-MMM-yy");
    > 
    >                 var items1 = new List<ListItem>();
    >                 items1.Add(new ListItem("", ""));
    >                 items1.Add(new ListItem { Text = "Month", Value = "month" });
    >                 items1.Add(new ListItem { Text = "Month + 2", Value = "2month" });
    >                 items1.Add(new ListItem { Text = "Month + 5", Value = "5month" });
    >                 items1.Add(new ListItem { Text = "Year", Value = "year" });
    >                 drpMonths.DataSource = items1;
    >                 drpMonths.DataTextField = "Text";
    >                 drpMonths.DataValueField = "Value";
    >                 drpMonths.DataBind();
    > 
    >                 var ddWeekdays = new List<ListItem>();
    >                 ddWeekdays.Add(new ListItem("", ""));
    >                 ddWeekdays.Add(new ListItem { Text = "Sunday", Value = "sunday" });
    >                 ddWeekdays.Add(new ListItem { Text = "Monday", Value = "Monday" });
    >                 ddWeekdays.Add(new ListItem { Text = "Tuesday", Value = "Tuesday" });
    >                 ddWeekdays.Add(new ListItem { Text = "Wednesday", Value = "Wednesday" });
    >                 ddWeekdays.Add(new ListItem { Text = "Thursday", Value = "Thursday" });
    >                 ddWeekdays.Add(new ListItem { Text = "Friday", Value = "Friday" });
    >                 ddWeekdays.Add(new ListItem { Text = "Saturday", Value = "Saturday" });
    >                 drpWeekdays.DataSource = ddWeekdays;
    >                 drpWeekdays.DataTextField = "Text";
    >                 drpWeekdays.DataValueField = "Value";
    >                 drpWeekdays.DataBind();
    > 
    >                 var ddinterval = new List<ListItem>();
    >                 ddinterval.Add(new ListItem("", ""));
    >                 ddinterval.Add(new ListItem { Text = "1", Value = "1" });
    >                 ddinterval.Add(new ListItem { Text = "2", Value = "2" });
    >                 ddinterval.Add(new ListItem { Text = "3", Value = "3" });
    >                 ddinterval.Add(new ListItem { Text = "4", Value = "4" });
    >                 ddinterval.Add(new ListItem { Text = "5", Value = "5" });
    >                 drpInterval.DataSource = ddinterval;
    >                 drpInterval.DataTextField = "Text";
    >                 drpInterval.DataValueField = "Value";
    >                 drpInterval.DataBind();
    >             }
    >         }
    > 
    >         protected void TextBox2_TextChanged(object sender, EventArgs e)
    >         {
    > 
    >         }
    > 
    >         protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    >         {
    > 
    >         }
    > 
    >         protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    >         {
    >             TextBox1.Text = Calendar1.SelectedDate.ToString("dd-MMM-yy");
    >         }
    > 
    >         protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    >         {
    >             TextBox2.Text = Calendar2.SelectedDate.ToString("dd-MMM-yy");
    >         }
    > 
    >         protected void btnSubmit_Click(object sender, EventArgs e)
    >         {
    >             var fromDate = Calendar1.SelectedDate;
    >             var todate = Calendar2.SelectedDate;
    >             var dateList = new List<DateTime>();
    >             if (fromDate != null && todate != null && (todate > fromDate))
    >             {
    >                 var fDate = fromDate;
    >                 bool flag = true;
    >                 while (fDate < todate)
    >                 {
    >                     if (!string.IsNullOrEmpty(drpMonths.SelectedValue))
    >                     {
    >                         flag = CheckMonth(fDate);
    >                     }
    >                     if (flag && !string.IsNullOrEmpty(drpWeekdays.SelectedValue))
    >                     {
    >                         flag = CheckDay(fDate);
    >                     }
    >                     if (flag && !string.IsNullOrEmpty(drpInterval.SelectedValue))
    >                     {
    >                         flag = CheckInterval(fDate);
    >                     }
    >                     if (flag)
    >                     {
    >                         dateList.Add(fDate);
    >                     }
    >                     fDate = fDate.AddDays(1);
    >                     flag = true;
    >                 }
    >                 BulletedList1.DataSource = dateList;
    >                 BulletedList1.DataBind();
    >             }
    >         }
    > 
    >         public DateTime? LastExecutedMonth = null;
    >         private bool CheckMonth(DateTime date)
    >         {
    >             var retVal = false;
    >             if (LastExecutedMonth == null)
    >             {
    >                 LastExecutedMonth = Calendar1.SelectedDate;
    >             }
    >            
    >             switch (drpMonths.SelectedValue.ToLower())
    >             {
    >                 case "month":
    >                     if (MonthDiff(Convert.ToDateTime(LastExecutedMonth), date) == 1)
    >                     {
    >                         retVal = true;
    >                         if (date == new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1))
    >                         {
    >                             LastExecutedMonth = date;
    >                         }
    >                     }
    >                     break;
    >                 case "2month":
    >                     if (MonthDiff(Convert.ToDateTime(LastExecutedMonth), date) == 2)
    >                     {
    >                         retVal = true;
    >                         if (date == new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1))
    >                         {
    >                             LastExecutedMonth = date;
    >                         }
    >                     }
    >                     break;
    >                 case "5month":
    >                     if (MonthDiff(Convert.ToDateTime(LastExecutedMonth), date) == 5)
    >                     {
    >                         retVal = true;
    >                         if (date == new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1))
    >                         {
    >                             LastExecutedMonth = date;
    >                         }
    >                     }
    >                     break;
    >                 case "year":
    >                     if (MonthDiff(Convert.ToDateTime(LastExecutedMonth), date) == 12)
    >                     {
    >                         retVal = true;
    >                         if (date == new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1))
    >                         {
    >                             LastExecutedMonth = date;
    >                         }
    >                     }
    >                     break;
    >             }
    >             return retVal;
    >         }
    > 
    >         private bool CheckDay(DateTime date)
    >         {
    >             var retval = false;
    >             switch (drpWeekdays.SelectedValue.ToLower())
    >             {
    >                 case "sunday":
    >                     retval = date.DayOfWeek == DayOfWeek.Sunday;
    >                     break;
    >                 case "monday":
    >                     retval = date.DayOfWeek == DayOfWeek.Monday;
    >                     break;
    >                 case "tuesday":
    >                     retval = date.DayOfWeek == DayOfWeek.Tuesday;
    >                     break;
    >                 case "wednesday":
    >                     retval = date.DayOfWeek == DayOfWeek.Wednesday;
    >                     break;
    >                 case "thursday":
    >                     retval = date.DayOfWeek == DayOfWeek.Thursday;
    >                     break;
    >                 case "friday":
    >                     retval = date.DayOfWeek == DayOfWeek.Friday;
    >                     break;
    >                 case "saturday":
    >                     retval = date.DayOfWeek == DayOfWeek.Saturday;
    >                     break;
    >             }
    >             return retval;
    >         }
    > 
    >         private bool CheckInterval(DateTime date)
    >         {
    >             var flag = false;
    >             switch (drpInterval.SelectedValue.ToLower())
    >             {
    >                 case "1":
    >                     flag = date == XthDayOfWeekInMonth(date.Year, date.Month, date.DayOfWeek, 1);
    >                     break;
    >                 case "2":
    >                     flag = date == XthDayOfWeekInMonth(date.Year, date.Month, date.DayOfWeek, 2);
    >                     break;
    >                 case "3":
    >                     flag = date == XthDayOfWeekInMonth(date.Year, date.Month, date.DayOfWeek, 3);
    >                     break;
    >                 case "4":
    >                     flag = date == XthDayOfWeekInMonth(date.Year, date.Month, date.DayOfWeek, 4);
    >                     break;
    >                 case "5":
    >                     flag = date == XthDayOfWeekInMonth(date.Year, date.Month, date.DayOfWeek, 5);
    >                     break;
    >             }
    >             return flag;
    >         }
    > 
    >         public static DateTime FirstDayOfWeekInMonth(int year, int month, DayOfWeek day)
    >         {
    >             DateTime res = new DateTime(year, month, 1);
    >             int offset = -(res.DayOfWeek - day);
    > 
    >             if (offset < 0)
    >                 offset += 7;
    > 
    >             res = res.AddDays(offset);
    > 
    >             return res;
    >         }
    > 
    >         public static DateTime LastDayOfWeekInMonth(int year, int month, DayOfWeek day)
    >         {
    >             DateTime res = FirstDayOfWeekInMonth(year, month + 1, day);
    > 
    >             res = res.AddDays(-7);
    > 
    >             return res;
    >         }
    > 
    >         public static DateTime XthDayOfWeekInMonth(int year, int month, DayOfWeek day, int x)
    >         {
    >             DateTime res = DateTime.MinValue;
    > 
    >             if (x > 0)
    >             {
    >                 res = FirstDayOfWeekInMonth(year, month, day);
    > 
    >                 if (x > 1)
    >                     res = res.AddDays((x - 1) * 7);
    > 
    >                 res = res.Year == year && res.Month == month ? res : DateTime.MinValue;
    >             }
    > 
    >             return res;
    >         }
    > 
    >         public static int MonthDiff(DateTime date1, DateTime date2)
    >         {
    >             if (date1.Month < date2.Month)
    >             {
    >                 return (date2.Year - date1.Year) * 12 + date2.Month - date1.Month;
    >             }
    >             else
    >             {
    >                 return (date2.Year - date1.Year - 1) * 12 + date2.Month - date1.Month + 12;
    >             }
    >         }
    >     } }
