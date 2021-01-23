	public static class Extensions
	{
		public static bool CheckUniformButtonState(this MouseButtonEventArgs e, MouseButtonState state)
		{
			switch (state)
			{
				case MouseButtonState.Pressed:
					return (e.LeftButton == MouseButtonState.Pressed &&
						e.RightButton == MouseButtonState.Pressed &&
						e.MiddleButton == MouseButtonState.Pressed &&
						e.XButton1 == MouseButtonState.Pressed &&
						e.XButton2 == MouseButtonState.Pressed);
				case MouseButtonState.Released:
					return (e.LeftButton == MouseButtonState.Released &&
						e.RightButton == MouseButtonState.Released &&
						e.MiddleButton == MouseButtonState.Released &&
						e.XButton1 == MouseButtonState.Released &&
						e.XButton2 == MouseButtonState.Released);
				default:
					return false;
			}
		}
	}
