    <EventTrigger SourceName="MainGrid" RoutedEvent="Grid.MouseEnter">
                <BeginStoryboard>
                    <Storyboard Storyboard.TargetName="DeleteButton"
                                Storyboard.TargetProperty="Foreground.Color">
                        <ColorAnimationUsingKeyFrames BeginTime="00:00:00">
                            <LinearColorKeyFrame Value="Red"
                                                 KeyTime="0:0:0" />
                        </ColorAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>            
            </EventTrigger>
            <EventTrigger SourceName="MainGrid"
                          RoutedEvent="Grid.MouseLeave">
                <BeginStoryboard >
                    <Storyboard Storyboard.TargetName="DeleteButton"
                                Storyboard.TargetProperty="Foreground.Color">
                        <ColorAnimationUsingKeyFrames BeginTime="00:00:00">
                            <LinearColorKeyFrame Value="Black"
                                                 KeyTime="0:0:0" />
                        </ColorAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>            
            </EventTrigger>
