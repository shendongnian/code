    <Hyperlink>
        <Hyperlink.Style>
            <Style TargetType="{x:Type Hyperlink}">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Hyperlink.Click">
                        <BeginStoryboard>
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility">
                                    <Storyboard.Target>
                                        <local:Dialogue />
                                    </Storyboard.Target>
                                    <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{x:Static Visibility.Visible}"/>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </Hyperlink.Style>
        <Hyperlink.Inlines>
            <Run Text="Open Dialogue"/>
        </Hyperlink.Inlines>
    </Hyperlink>
