	private void navigationData_PropertyChanged(object sender, EventArgs e)
	{
		compassRoseAnimation.From = navigationData.previousHeading;
		compassRoseAnimation.To = navigationData.heading;
		RotateTransform rotateTransform = new RotateTransform();
		CompassWithNumbersControl.RenderTransform = rotateTransform;
		rotateTransform.BeginAnimation(RotateTransform.AngleProperty, compassRoseAnimation);
	}
