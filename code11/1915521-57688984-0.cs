    public class AnimateBehavior : Behavior<Image>
    {
        public int Steps
        {
            get => (int)GetValue(StepsProperty);
            set => SetValue(StepsProperty, value);
        }
        public static readonly DependencyProperty StepsProperty =
            DependencyProperty.Register(nameof(Steps), typeof(int), typeof(AnimateBehavior), new PropertyMetadata(0, (d, e) => ((AnimateBehavior)d).StepsChanged(e)));
        private void StepsChanged(DependencyPropertyChangedEventArgs e)
        {
            if (AssociatedObject == null)
                return;
            AssociatedObject.RenderTransform.BeginAnimation(
                RotateTransform.AngleProperty,
                new DoubleAnimation()
                {
                    By = (int)e.NewValue * 72,
                    Duration = TimeSpan.FromSeconds(3),
                });
        }
    }
