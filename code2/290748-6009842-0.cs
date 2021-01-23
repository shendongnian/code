		public void WindowsScreenshot()
		{
			// Full
			Rectangle bounds = Screen.GetBounds(Point.Empty);
			using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
			{
				using (Graphics g = Graphics.FromImage(bitmap))
				{
					g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
				}
				bitmap.Save("test_full.jpg", ImageFormat.Jpeg);
			}
			// Window
			Rectangle bounds = this.Bounds;
			using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
			{
				using (Graphics g = Graphics.FromImage(bitmap))
				{
					g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
				}
				bitmap.Save("test_window.jpg", ImageFormat.Jpeg);
			}
		}
