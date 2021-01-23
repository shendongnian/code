	private void statisticsView_DrawItem(object sender,
		DrawListViewItemEventArgs e)
	{
		e.Graphics.FillRectangle(Brushes.White, e.Bounds);
		if((e.State & ListViewItemStates.Selected) != 0)
			e.DrawFocusRectangle();
		Rectangle bounds = e.Bounds;
		Font font = ((ListView)sender).Font;
		Font nameFont = new Font(font.FontFamily,
			font.Size,
			FontStyle.Underline | FontStyle.Bold,
			font.Unit,
			font.GdiCharSet,
			font.GdiVerticalFont);
		using(StringFormat sf = new StringFormat())
		{
			e.Graphics.DrawString(e.Item.SubItems[0].Text,
				nameFont, Brushes.Black, bounds, sf);
			bounds.Y += 17;
			for(int i = 1; i < e.Item.SubItems.Count; ++i, bounds.Y += 15)
				e.Graphics.DrawString(e.Item.SubItems[i].Text,
					font, Brushes.Black, bounds, sf);
		}
	}
