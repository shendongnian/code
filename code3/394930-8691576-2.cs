	static void AnimateScroll(UIElement element, double amount, TimeSpan duration)
	{
		var sb = new Storyboard();
		var position = Canvas.GetTop(element);
		if(double.IsNaN(position)) position = 0;
		var animation =
			new DoubleAnimation
			{
				// fine-tune animation here
				From = position,
				To = position + amount,
				Duration = new Duration(duration),
			};
		Storyboard.SetTarget(animation, element);
		Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
		sb.Children.Add(animation);
		sb.Begin();
	}
