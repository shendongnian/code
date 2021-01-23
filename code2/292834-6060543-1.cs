		private bool _mouseDown = false;
		private Rectangle _current;
		private Point _initialPoint;
		private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_mouseDown = (e.ButtonState == MouseButtonState.Pressed) 
                                         && (e.ChangedButton == MouseButton.Left);
			if (!_mouseDown)
				return;
			_current = new Rectangle();
			_initialPoint = e.MouseDevice.GetPosition(MyCanvas);
			_current.Fill = new SolidColorBrush(Colors.Blue);
			MyCanvas.Children.Add(_current);
		}
		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (!_mouseDown)
				return;
			Point position = e.MouseDevice.GetPosition(MyCanvas);
			if (position.X > _initialPoint.X)
			{
				_current.SetValue(Canvas.LeftProperty, _initialPoint.X);
				_current.Width = position.X - _initialPoint.X;
			}
			else
			{
				_current.SetValue(Canvas.LeftProperty, position.X);
				_current.Width = _initialPoint.X - position.X;
			}
			if (position.Y > _initialPoint.Y)
			{
				_current.SetValue(Canvas.TopProperty, _initialPoint.Y);
				_current.Height = position.Y - _initialPoint.Y;
			}
			else
			{
				_current.SetValue(Canvas.TopProperty, position.Y);
				_current.Height = _initialPoint.Y - position.Y;
			}
		}
		private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				_mouseDown = false;
		}
