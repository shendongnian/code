    protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				DataSet ds = GetDataSet();
				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					CreateRootTab(i, ds);
				}
				RadTabStrip1.SelectedIndex = 0;
			}
		}
		private void CreateRootTab(int index, DataSet ds)
		{
			for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
			{
				var tab = new RadTab();
				tab.Text = (string) ds.Tables[0].Rows[index].ItemArray[i];
				RadTabStrip1.Tabs.Add(tab);
			}
		}
		private DataSet GetDataSet()
		{
			bllQuesType objbllQuesQType = new bllQuesType();
			var ds = new DataSet();
			return objbllQuesType.GetQuesType();
		}
