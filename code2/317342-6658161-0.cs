	Action<TextBox> animMethod = (TextBox x) =>
		{
			var brush = new SolidColorBrush(Colors.Red);
			x.Visibility = Visibility.Visible;
			x.BorderBrush = brush;
			brush.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation(Colors.White, TimeSpan.FromSeconds(1)));
		};
	animMethod(tbtest);
