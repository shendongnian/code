    <StackPanel x:Name="MyStackPanel">...</StackPanel>
    ...
    <ToggleButton Content="Click Me">
        <ToggleButton.Triggers>
            <EventTrigger RoutedEvent="ToggleButton.Checked">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetName="MyStackPanel" 
                                         Storyboard.TargetProperty="Width"
                                         To="0"
                                         Duration="0:0:0.5" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="ToggleButton.Unchecked">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetName="MyStackPanel" 
                                         Storyboard.TargetProperty="Width"
                                         To="200"
                                         Duration="0:0:0.5" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </ToggleButton.Triggers>
    </ToggleButton>
