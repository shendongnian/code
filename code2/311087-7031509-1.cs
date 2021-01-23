    <Application.Resources>
    
    
            <Storyboard x:Key="Storyboard1">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="{Binding}">
                    <EasingDoubleKeyFrame KeyTime="0:0:1" Value="90"/>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)" Storyboard.TargetName="{Binding}">
                    <EasingDoubleKeyFrame KeyTime="0:0:1" Value="103"/>
                </DoubleAnimationUsingKeyFrames>
                <PointAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransformOrigin)" Storyboard.TargetName="{Binding}">
                    <EasingPointKeyFrame KeyTime="0:0:1" Value="0.75,0.5"/>
                </PointAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)" Storyboard.TargetName="{Binding}">
                    <EasingDoubleKeyFrame KeyTime="0:0:1" Value="75"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
--
    step 4
    
    //create a method to make it easy to run the same animation on multiple objects:
    
    void runStoryboard(string storyboardName, string objectName)
    {
        Storyboard sb = FindResource(storyboardName) as Storyboard;
    
        foreach (var child in sb.Children)            
            Storyboard.SetTargetName(child, objectName);
    
        sb.Begin(this); // do not forget the this keyword
    }
