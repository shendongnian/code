    protected void Page_Load(object sender, EventArgs e)
    {
          if (!Page.IsPostBack)
          {
                if (!this.ClientScript.IsStartupScriptRegistered("startup"))
                {
                      StringBuilder sb = new StringBuilder();
                      sb.Append("&lt;script type='text/javascript'>");
                      sb.Append("Sys.Application.add_load(modalSetup);");
                      sb.Append("function modalSetup() {");
                      sb.Append(String.Format("var modalPopup = $find('{0}');", popupEntry.BehaviorID));
                      sb.Append("modalPopup.add_shown(SetFocusOnControl); }");
                      sb.Append("function SetFocusOnControl() {");
                      sb.Append(String.Format("var textBox1 = $get('{0}');", txtValue.ClientID));
                      sb.Append("textBox1.focus();}");
                      sb.Append("&lt;/script>");
                      Page.ClientScript.RegisterStartupScript(Page.GetType(), "startup", sb.ToString());
                 }
          }
    }
