    public static void Animate(this object target, DependencyProperty property, AnimationTimeline animation)
    {
        target.ThrowIfNull();
        DoAnimate(target as dynamic);
    }
    private static void DoAnimate(object target, DependencyProperty property, AnimationTimeline animation)
    {
        throw new ArgumentException("The target is not animatable")
    }
    private static void DoAnimate(Animatable target, DependencyProperty property, AnimationTimeline animation)
    {
        target.BeginAnimation(property, animation);
    }
    private static void DoAnimate(UIElement target, DependencyProperty property, AnimationTimeline animation)
    {
        target.BeginAnimation(property, animation);
    }
