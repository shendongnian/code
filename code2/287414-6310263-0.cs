// complete code for the animation behavior
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
namespace ColorAnimationBehavior
{
	public class ColorAnimationBehavior: TriggerAction&lt;UIElement>
	{
		public Color FillColor
		{
			get { return (Color)GetValue(FillColorProperty); }
			set { SetValue(FillColorProperty, value); }
		}
		public static readonly DependencyProperty FillColorProperty =
			DependencyProperty.Register("FillColor", typeof(Color), typeof(ColorAnimationBehavior), null);
		public Duration Duration
		{
			get { return (Duration)GetValue(DurationProperty); }
			set { SetValue(DurationProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Duration.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DurationProperty =
			DependencyProperty.Register("Duration", typeof(Duration), typeof(ColorAnimationBehavior), null);
		protected override void Invoke(object parameter)
		{
			var storyboard = new Storyboard();
			storyboard.Children.Add(CreateColorAnimation(this.AssociatedObject, this.Duration, this.FillColor));
			storyboard.Begin();
		}
		private static ColorAnimationUsingKeyFrames CreateColorAnimation(UIElement element, Duration duration, Color color)
		{
			var animation = new ColorAnimationUsingKeyFrames();
			animation.KeyFrames.Add(new SplineColorKeyFrame() { KeyTime = duration.TimeSpan, Value = color });
			Storyboard.SetTargetProperty(animation, new PropertyPath("(Shape.Fill).(SolidColorBrush.Color)"));
			Storyboard.SetTarget(animation, element);
			return animation;
		}
	}
}
