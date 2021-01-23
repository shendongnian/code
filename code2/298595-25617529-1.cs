	int counter = 0
	  , columnCount = 3;
	rptTest.ItemDataBound += (rpt_sender, rpt_e) => {
		if (rpt_e.Item.ItemType == ListItemType.Item || rpt_e.Item.ItemType == ListItemType.AlternatingItem) {
			string cellData = (string)rpt_e.Item.DataItem;
			Literal litContent = (Literal)rpt_e.Item.FindControl("litContent");
			litContent.Text = cellData;
		}
		else if (rpt_e.Item.ItemType == ListItemType.Separator) {
			if (++counter % columnCount != 0)
				rpt_e.Item.Visible = false;
		}
	};
	rptTest.DataSource = new string[] { "Cell 1", "Cell 2", "Cell 3", "Cell 4", "Cell 5", "Cell 6", "Cell 7", "Cell 8", "Cell 9", "Cell 10" };
	rptTest.DataBind();
