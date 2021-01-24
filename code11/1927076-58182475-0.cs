    <Grid Height="180" Width="180">
        <Image Height="180" Width="180" Source="{Binding Result}" Grid.Column="1">
            <Image.LayoutTransform>
                <ScaleTransform x:Name="st" CenterX="90" CenterY="90" ScaleX="1" ScaleY="1" />
            </Image.LayoutTransform>
            <Image.Triggers>
                <EventTrigger RoutedEvent="Image.MouseEnter">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="st"
                                                 Storyboard.TargetProperty="(ScaleTransform.ScaleX)"
                                                 To="3.0" Duration="0:0:0" />
                                <DoubleAnimation Storyboard.TargetName="st"
                                                 Storyboard.TargetProperty="(ScaleTransform.ScaleY)"
                                                 To="3.0" Duration="0:0:0" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
                <EventTrigger RoutedEvent="Image.MouseLeave">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="st"
                                                 Storyboard.TargetProperty="(ScaleTransform.ScaleX)"
                                                 To="1.0" Duration="0:0:0" />
                                <DoubleAnimation Storyboard.TargetName="st"
                                                 Storyboard.TargetProperty="(ScaleTransform.ScaleY)"
                                                 To="1.0" Duration="0:0:0" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
            </Image.Triggers>
        </Image>
    </Grid>
