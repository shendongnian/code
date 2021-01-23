    Dim sb As New Storyboard
            Dim dauk3 As New DoubleAnimationUsingKeyFrames
            dauk3.BeginTime = New TimeSpan(0)
            dauk3.SetValue(Storyboard.TargetNameProperty, target)
            dauk3.SetValue(Storyboard.TargetPropertyProperty, New PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)"))
    
    'The keyframe below resets the animation at time 0
            Dim sdk0 As New SplineDoubleKeyFrame()
            sdk0.KeyTime = TimeSpan.FromSeconds(0)
            sdk0.Value = 0
    'The keyframe above resets the animation at time 0
    
            Dim sdk As New SplineDoubleKeyFrame()
            sdk.KeyTime = TimeSpan.FromSeconds(span)
            sdk.Value = width
    
            dauk3.KeyFrames.Add(sdk0)
            dauk3.KeyFrames.Add(sdk)
            sb.Children.Add(dauk3)
            sb.Begin(Me, True)
