    <Grid Background="White">
        <Grid.CommandBindings>
            <CommandBinding Command="Close" Executed="CommandBinding_Executed"/>
        </Grid.CommandBindings>
        <!--<Grid.InputBindings>
            <MouseBinding Command="Close" MouseAction="RightClick"/>
        </Grid.InputBindings>-->
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseRightButtonUp">
                <utils:ExecuteCommand Command="Close"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
        <StackPanel>
            <TextBox Text="Some Text"/>
        </StackPanel>
    </Grid>
