    <body>
        <form id="form1" runat="server">
        <div>
        <asp:Button runat="server" Text="Click Me" OnClick="go_" />
        </div>
        </form>
    </body>
    public partial class WebForm1 : System.Web.UI.Page
	{
		public int ControlCount
		{
			get { return ViewState["Controls"] == null ? 0 : (int)ViewState["Controls"]; }
			set { ViewState.Add("Controls", value); }
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			for(int i = 0; i < ControlCount; i++)
			{
				Button b = new Button();
				b.Click += btn_Click;
				b.Text = "Hi";
				form1.Controls.Add(b);
			}
		}
		void btn_Click(object sender, EventArgs e)
		{
			((Button)sender).Text = "bye";
		}
		protected void go_(object sender, EventArgs e)
		{
			Button btn = new Button();
			btn.Text = "Hi";
			form1.Controls.Add(btn);
			btn.Click += new EventHandler(btn_Click);
			ControlCount++;
		}
	}
