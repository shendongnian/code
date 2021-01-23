    public partial class asyncLongLasting : System.Web.UI.Page
    {
       protected void btnStart_Click(object sender, EventArgs e)
       {
           // your database query may start here
           System.Threading.Thread.Sleep(5000);
       }
    }
