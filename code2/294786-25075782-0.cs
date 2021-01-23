    public class MonthCalendarBuffered : MonthCalendar
    {
        protected override void CreateHandle()
        {
           Application.VisualStyleState = VisualStyleState.NoneEnabled;     
           // disables Application.UseVisualStyles
           base.CreateHandle();
           // restore setting
           Application.VisualStyleState = VisualStyleState.ClientAndNonClientAreasEnabled;
        }
     ...
