    <Grid Background="Red" >
        <Grid.Triggers>
            <EventTrigger RoutedEvent="MouseDown">
                <BeginStoryboard>
                    <Storyboard x:Key="">
                        <DoubleAnimation To="0" Duration="00:00:01" Storyboard.TargetProperty="Opacity" AutoReverse="True" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Grid.Triggers>
    </Grid>
