    <Trigger Property="IsMouseOver" Value="True">
        <Trigger.EnterActions>
            <BeginStoryboard>
                <Storyboard>
                    <DoubleAnimation
                        Storyboard.TargetProperty="Opacity"
                        To="1" Duration="0:0:0.3"/>
                </Storyboard>
            </BeginStoryboard>
        </Trigger.EnterActions>
        <Trigger.ExitActions>
            <BeginStoryboard>
                <Storyboard>
                    <DoubleAnimation
                        Storyboard.TargetProperty="Opacity"
                        To=".7" Duration="0:0:0.3" />
                </Storyboard>
            </BeginStoryboard>
        </Trigger.ExitActions>
    </Trigger>
