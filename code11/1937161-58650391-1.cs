    public partial class ImageCheckBoxList : System.Web.UI.UserControl
    {
        public IList<ImageListItem> Items { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = Items;
                Repeater1.DataBind();
            }
    
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                var checkBox = (CheckBox)Repeater1.Items[i].FindControl("CheckBox1");
                if (checkBox != null)
                {
                    Items[i].Checked = checkBox.Checked;
                }
            }
        }
    }
