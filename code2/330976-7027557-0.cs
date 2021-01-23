    <Grid.Triggers>
      <EventTrigger RoutedEvent="Grid.MouseEnter">
        <BeginStoryboard>
          <Storyboard>
            <DoubleAnimation Storyboard.TargetName="SomeGrid" Storyboard.TargetProperty="Height" AccelerationRatio="0.5" DecelerationRatio="0.5" From="40.0" To="140.0" Duration="0:0:1" />
          </Storyboard>
        </BeginStoryboard>
      </EventTrigger>
      <EventTrigger RoutedEvent="Grid.MouseLeave">
        <BeginStoryboard>
          <Storyboard>
            <DoubleAnimation Storyboard.TargetName="SomeGrid" Storyboard.TargetProperty="Height" AccelerationRatio="0.5" DecelerationRatio="0.5" From="140.0" To="40.0" Duration="0:0:1" />
          </Storyboard>
        </BeginStoryboard>
      </EventTrigger>
    </Grid.Triggers>
