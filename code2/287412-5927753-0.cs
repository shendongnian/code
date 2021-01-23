       public class ColorAnimationBehavior : TriggerAction<FrameworkElement>
        {
            #region Fill color
            [Description("The background color of the rectangle")]
            public Color FillColor
            {
                get { return (Color)GetValue(FillColorProperty); }
                set { SetValue(FillColorProperty, value); }
            }
    
            public static readonly DependencyProperty FillColorProperty =
                DependencyProperty.Register("FillColor", typeof(Color), typeof(ColorAnimationBehavior), null);
            #endregion
    
            protected override void Invoke(object parameter)
            {
                var rect = (Rectangle)AssociatedObject;
    
                var sb = new Storyboard();
                sb.Children.Add(CreateVisibilityAnimation(rect, new Duration(new TimeSpan(0, 0, 1)), FillColor));
    
                sb.Begin();
            }
    
            private static ColorAnimationUsingKeyFrames CreateVisibilityAnimation(DependencyObject element, Duration duration, Color color)
            {
                var animation = new ColorAnimationUsingKeyFrames();
    
                animation.KeyFrames.Add(new SplineColorKeyFrame { KeyTime = new TimeSpan(duration.TimeSpan.Ticks), Value = color });
    
                Storyboard.SetTargetProperty(animation, new PropertyPath("(Shape.Fill).(SolidColorBrush.Color)"));
                Storyboard.SetTarget(animation, element);
    
                return animation;
            }
    
        }
