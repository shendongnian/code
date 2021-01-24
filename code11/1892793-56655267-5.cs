    <TextBlock Text="Hello, World.">
        <TextBlock.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames
                            Storyboard.TargetProperty="Visibility"
                            Duration="0:0:4" RepeatBehavior="Forever">
                            <DiscreteObjectKeyFrame
                                KeyTime="0:0:0"
                                Value="{x:Static Visibility.Visible}"/>
                            <DiscreteObjectKeyFrame
                                KeyTime="0:0:2"
                                Value="{x:Static Visibility.Hidden}"/>
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </TextBlock.Triggers>
    </TextBlock>
