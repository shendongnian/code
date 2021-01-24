xml
<Button Content="Yo!">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Grid x:Name="Root" Width="100" Height="100">
                <Grid.Background>
                    <RevealBackgroundBrush/>
                </Grid.Background>
                <VisualStateManager.VisualStateGroups>
                    <VisualStateGroup x:Name="CommonStates">
                        <VisualState x:Name="Normal" />
                        <VisualState x:Name="PointerOver">
                            <VisualState.Setters>
                                <Setter Target="Root.(RevealBrush.State)" Value="PointerOver"/>
                            </VisualState.Setters>
                        </VisualState>
                        <VisualState x:Name="PointerOverPressed">
                            <VisualState.Setters>
                                <Setter Target="Root.(RevealBrush.State)" Value="Pressed"/>
                            </VisualState.Setters>
                        </VisualState>
                        <VisualState x:Name="Pressed">
                            <VisualState.Setters>
                                <Setter Target="Root.(RevealBrush.State)" Value="Pressed"/>
                            </VisualState.Setters>
                        </VisualState>
                    </VisualStateGroup>
                    <VisualStateGroup x:Name="DisabledStates">
                        <VisualState x:Name="Enabled"/>
                        <VisualState x:Name="Disabled">
                            <VisualState.Setters>
                                <Setter Target="Root.RevealBorderThickness" Value="0"/>
                            </VisualState.Setters>
                        </VisualState>
                    </VisualStateGroup>
                </VisualStateManager.VisualStateGroups>
                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
            </Grid>
        </ControlTemplate>
    </Button.Template>
    
</Button>
We use `VisualStateManager` for state management and adjust the state of Reveal.
The same reason can be applied to other controls.
Best regards.
