`c#
private void Button_Click(object sender, RoutedEventArgs e)
{
	double offsetx = ((brd2.RenderTransform as TransformGroup).Children[3] as TranslateTransform).X;
	double offsety = ((brd2.RenderTransform as TransformGroup).Children[3] as TranslateTransform).Y;
	Point point = brd2.TranslatePoint(new Point(brd2.RenderTransformOrigin.X * brd2.RenderSize.Width, brd2.RenderTransformOrigin.Y * brd2.RenderSize.Height), canvas2);
	canvas1.Children.Remove(brd2);
	brd2.Background = Brushes.Green;
	brd2.Opacity = 0.4;
	canvas2.Children.Add(brd2);
	Canvas.SetLeft(brd2, point.X - brd2.RenderTransformOrigin.X * brd2.RenderSize.Width - offsetx);
	Canvas.SetTop(brd2, point.Y - brd2.RenderTransformOrigin.Y * brd2.RenderSize.Height - offsety);
	((brd2.RenderTransform as TransformGroup).Children[2] as RotateTransform).Angle +=
	   ((canvas1.RenderTransform as TransformGroup).Children[2] as RotateTransform).Angle;
}
`
