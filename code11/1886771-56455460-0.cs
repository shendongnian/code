    private void StartAnimation(Grid GridColor, double GridHight)
    {
        storyboard1 = new Storyboard();
        var AnimationOne = new EasingDoubleKeyFrame() {
            KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(600)),
            Value = GridHight,
            EasingFunction = new QuarticEase() { EasingMode = EasingMode.EaseOut } };
        var AnimOne = new DoubleAnimationUsingKeyFrames();
        AnimOne.EnableDependentAnimation = true;
        AnimOne.KeyFrames.Add(AnimationOne);
        Storyboard.SetTargetProperty(AnimOne, "(FrameworkElement.Height)");
        Storyboard.SetTarget(AnimOne, GridColor);
        storyboard1.Children.Add(AnimOne);
        storyboard1.Begin();
    }
