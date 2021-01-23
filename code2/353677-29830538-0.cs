	private class SelectOnMouseUpListViewItem: ListViewItem
	{
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (IsSelected)
				e.Handled = true;
			base.OnMouseLeftButtonDown(e);
		}
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			if (!IsSelected)
				base.OnMouseLeftButtonDown(e);
			base.OnMouseLeftButtonUp(e);
		}
	}
	protected override DependencyObject GetContainerForItemOverride() // in ListView
	{
		return new SelectOnMouseUpListViewItem();
	}
