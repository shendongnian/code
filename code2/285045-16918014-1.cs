        <Trigger Property="IsChecked" Value="True">
            <Trigger.ExitActions>
                <BeginStoryboard x:Name="CheckedOff_BeginStoryboard" Storyboard="{StaticResource CheckedOff}" />
            </Trigger.ExitActions>
            <Trigger.EnterActions>
                <BeginStoryboard x:Name="CheckedOn_BeginStoryboard" Storyboard="{StaticResource CheckedOn}" />
            </Trigger.EnterActions>
        </Trigger>
