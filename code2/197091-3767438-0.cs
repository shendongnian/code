    ColorAnimation mouseEnterColorAnimation = new ColorAnimation();
    mouseEnterColorAnimation.To = Colors.Red;
    mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(5);
    myAnimatedBrush.BeginAnimation(SolidColorBrush.ColorProperty, null); // remove the old animation to prevent memoryleak
    myAnimatedBrush.BeginAnimation(SolidColorBrush.ColorProperty, mouseEnterColorAnimation);
