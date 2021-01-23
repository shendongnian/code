    <Style>
        <Style.Triggers>
            <DataTrigger Binding="{Binding Vanishing}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard TargetProperty="Opacity">
                            <DoubleAnimation To="0" Duration="0:0:0.5" FillBehavior="Stop"/>
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                    <BeginStoryboard>
                        <Storyboard TargetProperty="Opacity">
                            <DoubleAnimation To="{x:Null}" Duration="0:0:0"/>
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.ExitActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
