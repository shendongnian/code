    <Path Data="M 5,0 0,10 10,10" Height="10" Width="10" Fill="Green" Opacity="{Binding MyValue[0].UpVisibility}" Margin="5,0,5,0">
        <Path.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding MyValue[0].UpVisibility}" Value="1.0">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Opacity" From="1.0" To="0.0" Duration="0:0:10" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Opacity" To="0.0" Duration="0:0:0" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Path.Style>
    </Path>
