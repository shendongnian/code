    private void TreePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		_startPoint = e.GetPosition(null);
		_checkDragDrop = true;
	}
	private void TempTreeMouseMove(object sender, MouseEventArgs e)
	{
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			var mousePos = e.GetPosition(null);
			var diff = _startPoint - mousePos;
			if (_checkDragDrop)
			{
				if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
				{
					_checkDragDrop = false;
					.
					.
					.
					DragDropEffects val = DragDrop.DoDragDrop(DragSourceList, dragData, DragDropEffects.Move);
						
				}
			}
		}
	}
