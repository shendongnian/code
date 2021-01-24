cs
public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register(
	"StartAngle",
	typeof(int),
	typeof(Pie),
	new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.AffectsRender)
);
And leave your getter/setter like this:
cs
public int StartAngle {
	get { return (int)GetValue(StartAngleProperty); }
	set { SetValue(StartAngleProperty, value); }
}
Now you'll see your control redrawing when moving the slider.
