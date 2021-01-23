	GridSquare lastClicked = null;
	Color lastBackColor = Color.Transparent;
	
	Action<GridSquare> clicked = gs =>
	{
		lastClicked.BackColor = lastBackColor;
		if (!lastClicked.Equals(gs))
		{
			lastClicked = gs;
			lastBackColor = gs.BackColor;
			gs.BackColor = Color.LightBlue;
			var inner = gs.Piece != null
			    ? String.Format("a {0} at ", gs.Piece.GetName())
			    : "";
			var msg = String.Format("You clicked {0}({1}, {2})", inner, gs.X, gs.Y);
			MessageBox.Show(msg);
		}
	};
