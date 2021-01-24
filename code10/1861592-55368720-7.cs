        private void AnimationValue()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = _lastValue,
                To = Value,
                Duration = TimeSpan.FromSeconds(2),
                EasingFunction = new CubicEase(),
                EnableDependentAnimation = true
            };
            Storyboard.SetTarget(animation, Slider);
            Storyboard.SetTargetProperty(animation, "Value");
            storyboard.BeginTime = TimeSpan.Zero;
            storyboard.Children.Add(animation);
            storyboard.Begin();
            _storyboard = storyboard;
        }
