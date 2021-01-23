    public partial class ScriptAdd : System.Web.UI.Page
    {
        private List<MyItem> tempMyItems
        {
            get
            {
                //if (ViewState["tempMyItemsList"] == null)
                //    ViewState["tempMyItemsList"] = new List<MyItem>();
                
                return (List<MyItem>)ViewState["tempMyItemsList"];
            }
            set
            {
                ViewState.Add("tempMyItemsList", value);
            }
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            // ...
        }
    }
