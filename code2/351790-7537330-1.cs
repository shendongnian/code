    public partial class Two : System.Web.UI.Page, ISearch 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ISearch search = (ISearch)  PreviousPage;
            Label1.Text = search.SearchText;
        }
        public string SearchText
        {
            get
            {
                throw new NotImplementedException();
            }
            
        }
    }
