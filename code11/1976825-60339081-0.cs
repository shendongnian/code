    public partial class WebForm1 : System.Web.UI.Page
    {
            protected String[] cat = { "Customer", "Librarian", "Book Seller" };
            protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {   
                    List<string> category = cat.ToList(); 
                    DropDownList1.DataSource = category ;
                    DropDownList1.DataBind();
                }
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
            }
    }
