    public class MyPage : System.Web.UI.Page
    {
       // common logic that both pages should have
       protected void Page_Load(object sender, EventArgs e)
       {
       }
    }
    
    public partial class PageA : MyPage
    {
       // specific logic for page A
    }
    
    public partial class PageB : MyPage
    {
       // specific logic for page B
    }
