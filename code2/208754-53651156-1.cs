    	protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				int printId;
				if (Request.QueryString["printId"] != null && int.TryParse(Request.QueryString["printId"], out printId))
				{
					// Serve the file
				}
				else
				{
                    // Regular initialization
				}
			}
		}
