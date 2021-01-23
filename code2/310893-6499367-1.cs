            <Window.Resources> 
        <Storyboard x:Key="HoverOn"> 
            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetProperty="(UIElement.Opacity)"> 
                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0.8"/> 
            </DoubleAnimationUsingKeyFrames> 
        </Storyboard> 
        <Storyboard x:Key="HoverOff" Completed="Storyboard_Completed"> 
            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetProperty="(UIElement.Opacity)"> 
                <SplineDoubleKeyFrame KeyTime="00:00:00.5000000" Value="0.3"/> 
            </DoubleAnimationUsingKeyFrames> 
        </Storyboard> 
        <Style TargetType="{x:Type MenuItem}"> 
            <Style.Triggers> 
            <EventTrigger RoutedEvent="Mouse.MouseEnter" > 
                <BeginStoryboard Storyboard="{StaticResource HoverOn}"/> 
            </EventTrigger> 
            <EventTrigger RoutedEvent="Mouse.MouseLeave"> 
                <BeginStoryboard Storyboard="{StaticResource HoverOff}"/> 
            </EventTrigger> 
            </Style.Triggers> 
        </Style> 
    </Window.Resources> 
