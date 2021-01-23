    public partial class ViewEdit : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string x = Request.QueryString["ProductId"];
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                string editQuery = "SELECT CustId, CustName, SicNaic, CustCity, CustAdd, CustState, CustZip, BroName, BroId, BroAdd, BroCity, BroState, BroZip, EntityType, Coverage, CurrentCoverage, PrimEx, Retention, EffectiveDate, Commission, Premium, Comments, ProductId FROM ProductInstance WHERE ProductId =" + x;
    
    
    
            using (SqlConnection editConn = new SqlConnection(connectionString))
            {
                editConn.Open();
    
                using (SqlCommand command = new SqlCommand(editQuery, editConn))
                { [...]
