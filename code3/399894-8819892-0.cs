    public partial class Foo : System.Web.UI.Page
    {
       TimePeriod [] timePeriodArray = new TimePeriod[2];
       protected void Page_Load(object sender, EventArgs e)
       {
         for(int i=0;i<2;i++)
         {
             TimePeriod ib = (TimePeriod)LoadControl("TimePeriod.ascx");
             span_tempList.Controls.Add(ib);
             timePeriodArray[i] = ib;
         }
       }
