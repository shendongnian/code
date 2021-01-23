    <Style TargetType="ListBoxItem">
        <Style.Triggers>
            <Trigger Property="IsKeyboardFocusWithin" Value="True">
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsSelected">
                                <DiscreteBooleanKeyFrame KeyTime="0:0:0.0" Value="True"/>
                            </BooleanAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
            </Trigger>
        </Style.Triggers>
    </Style>
