    public void Magnifier(Canvas imgCanvas, Image imgObject, Canvas imgCanvasMagnifier, Image imgMagnifier, MouseEventArgs e)
		{
			Double width = imgCanvasMagnifier.Width;
			Double height = imgCanvasMagnifier.Height;
			Int32 zoom = 3;
			String txtDebug = String.Empty;
			String txtZoom = String.Empty;
			if (imgMagnifier.Source != imgObject.Source)
			{
				imgMagnifier.Source = imgObject.Source;
			}
			Size size = imgObject.RenderSize;
			RotateTransform rt = (RotateTransform)imgObject.LayoutTransform;
			TranslateTransform tt = (TranslateTransform)((TransformGroup)imgObject.RenderTransform).Children[1];
			ScaleTransform st = (ScaleTransform)((System.Windows.Media.TransformGroup)(imgObject.RenderTransform)).Children[0];
			Double x = e.GetPosition(imgCanvas).X - tt.X;
			Double y = e.GetPosition(imgCanvas).Y - tt.Y;
			Point pos = e.MouseDevice.GetPosition(imgCanvas);
			var wnd = Canvas.GetTop(imgObject);
			
			TransformGroup transformGroup = new TransformGroup();
			ScaleTransform scale = new ScaleTransform();
			scale.ScaleX = st.ScaleX * zoom;
			scale.ScaleY = st.ScaleY * zoom;
			RotateTransform rotate = new RotateTransform();
			rotate.Angle = rt.Angle;
			TranslateTransform translate = new TranslateTransform();
			Double centerX = st.CenterX * (st.ScaleX - 1);
			Double centerY = st.CenterY * (st.ScaleY - 1);
			if (rt.Angle == 0)
			{
				translate.X = -(x + centerX) / st.ScaleX;
				translate.Y = -(y + centerY) / st.ScaleY;
				scale.CenterX = (x + centerX) / st.ScaleX;
				scale.CenterY = (y + centerY) / st.ScaleY;
			}
			if (rt.Angle == 90)
			{
				translate.X = -(x + centerX) / st.ScaleX;
				translate.Y = -(y + centerY) / st.ScaleY;
				translate.X += imgObject.ActualHeight * st.ScaleX * zoom;
				scale.CenterX = (x + centerX) / st.ScaleX;
				scale.CenterY = (y + centerY) / st.ScaleY;
			}
			if (rt.Angle == 180)
			{
				translate.X = -(x + centerX) / st.ScaleX;
				translate.Y = -(y + centerY) / st.ScaleY;
				translate.X += imgObject.ActualWidth * st.ScaleX * zoom;
				translate.Y += imgObject.ActualHeight * st.ScaleY * zoom;
				scale.CenterX = (x + centerX) / st.ScaleX;
				scale.CenterY = (y + centerY) / st.ScaleY;
			}
			if (rt.Angle == 270)
			{
				translate.X = -(x + centerX) / st.ScaleX;
				translate.Y = -(y + centerY) / st.ScaleY;
				translate.Y += imgObject.ActualWidth * st.ScaleX * zoom;
				scale.CenterX = (x + centerX) / st.ScaleX;
				scale.CenterY = (y + centerY) / st.ScaleY;
			}
			translate.X += width / 2;
			translate.Y += height / 2;
			transformGroup.Children.Add(rotate);
			transformGroup.Children.Add(scale);
			transformGroup.Children.Add(translate);
			imgMagnifier.RenderTransform = transformGroup;
		}
