      <Storyboard Name="sbFlip" x:Key="sbFlip">
            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="frontSideContainer"  Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                <SplineDoubleKeyFrame KeyTime="00:00:00.2" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00.2" Storyboard.TargetName="backPanel" Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                <SplineDoubleKeyFrame KeyTime="00:00:00.3" Value="1"/>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
        <Storyboard x:Name="sbReverse" x:Key="sbReverse">
            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="backPanel"  Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                <SplineDoubleKeyFrame KeyTime="00:00:00.2" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00.2" Storyboard.TargetName="frontSideContainer" Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                <SplineDoubleKeyFrame KeyTime="00:00:00.3" Value="1"/>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
