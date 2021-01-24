    <Grid>
        <Grid.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation
                            Storyboard.TargetName="Border"
                            Storyboard.TargetProperty="Background.Opacity"
                            To="0" Duration="0:0:1"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Grid.Triggers>
        <Border x:Name="Border">
            <Border.Background>
                <SolidColorBrush Color="Red"/>
            </Border.Background>
        </Border>
    </Grid>
