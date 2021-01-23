Based on IDWMaster's solution I did it a bit differently using the System.Windows.Forms.UserControl. Otherwise the bindings were not up-to-date when the export to bitmap happened. This works for me (this is the WPF control to render):
    System.Windows.Forms.UserControl controlContainer = new System.Windows.Forms.UserControl();
	controlContainer.Width = width;
	controlContainer.Height = height;
	controlContainer.Load += delegate(object sender, EventArgs e)
	{
		this.Dispatcher.BeginInvoke((Action)delegate
		{
			using (FileStream fs = new FileStream(path, FileMode.Create))
			{
				RenderTargetBitmap bmp = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
				bmp.Render(this);
				BitmapEncoder encoder = new PngBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(bmp));
				encoder.Save(fs);
				controlContainer.Dispose();
			}
		}, DispatcherPriority.Background);
	};
	controlContainer.Controls.Add(new ElementHost() { Child = this, Dock = System.Windows.Forms.DockStyle.Fill });
	IntPtr handle = controlContainer.Handle;
