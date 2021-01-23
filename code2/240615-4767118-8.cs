        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //...
			this.Dispatcher.Hooks.DispatcherInactive += new EventHandler(Hooks_DispatcherInactive);
        }
    	void Hooks_DispatcherInactive(object sender, EventArgs e)
		{
			using (Image<Bgr, byte> frame = capture.QueryFrame())
			{
				if (frame != null)
				{
					using (var stream = new MemoryStream())
					{
						// My way to display frame 
						frame.Bitmap.Save(stream, ImageFormat.Bmp);
						BitmapImage bitmap = new BitmapImage();
						bitmap.BeginInit();
						bitmap.StreamSource = new MemoryStream(stream.ToArray());
						bitmap.EndInit();
						webcam.Source = bitmap;
					};
				}
			}
		}
