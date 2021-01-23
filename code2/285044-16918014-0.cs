        <Trigger Property="IsChecked" Value="false">
            <Trigger.ExitActions>
                <BeginStoryboard x:Name="CheckedOn_BeginStoryboard" Storyboard="{StaticResource CheckedOn}" />
            </Trigger.ExitActions>
            <Trigger.EnterActions>
                <BeginStoryboard x:Name="CheckedOff_BeginStoryboard" Storyboard="{StaticResource CheckedOff}" />
            </Trigger.EnterActions>
        </Trigger>
        <Trigger Property="IsChecked" Value="True" />
