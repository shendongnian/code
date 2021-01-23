	// Page load event
	protected void Page_Load(object sender, EventArgs e)
    {
		// Avoids calling this code if the call is a postback
		if (!IsPostBack)
		{
			// Some Code Here
		}
		else if(Request.Params.Get("__EVENTTARGET").ToString() == "ReturnedIndexes")
		{
			// Returns highlighted results
			String ReturnIndexes = Request.Params.Get("__EVENTARGUMENT").ToString();
			txtRowIndexes.Text = ReturnIndexes;
			int[] GridIndex = RowHighlightChanged();
			for (int i = 0; i < GridIndex.Length; i++)
			{
				if (GridView1.Rows[GridIndex[i]].CssClass == "gridHighlightedRow")
				{
					GridView1.Rows[GridIndex[i]].CssClass = "gridNormalRow";
				}
				else GridView1.Rows[GridIndex[i]].CssClass = "gridHighlightedRow";
			}
		}
	}
