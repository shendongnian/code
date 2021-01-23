    public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    List<CodeValue> colors = new List<CodeValue> {new CodeValue{Code="",Value="Select"},new CodeValue{Code="RD",Value="Red"},
                new CodeValue{Code="BL",Value="Blue"}};
                    ddlColors.DataSource = colors;
                    ddlColors.DataBind();
                }
            }
    
            protected void btnClick_Click(object sender, EventArgs e)
            {
                var item = ddlColors.SelectedValue;
                var code = item.Split('-');
            }
        }
    
        class CodeValue
        {
            public string Code { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                return this.Code + "-" + this.Value;
            }
        }
