		private void OnMouseMoveHandler(object sender, MouseEventArgs args)
		{
			if ((sender as FrameworkElement).ToolTip == null)
				(sender as FrameworkElement).ToolTip = new ToolTip() { Placement = PlacementMode.Relative };
			double x = args.GetPosition((sender as FrameworkElement)).X;
			double y = args.GetPosition((sender as FrameworkElement)).Y;
			var tip = ((sender as FrameworkElement).ToolTip as ToolTip);
			tip.Content = tooltip_text;
			tip.HorizontalOffset = x + 10;
			tip.VerticalOffset = y + 10;
        }
