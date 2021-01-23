    <ControlTemplate TargetType="controls:MyCustomComboBox">
         <Grid x:Name="VisualRoot">
                        ...
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates" ei:ExtendedVisualStateManager.UseFluidLayout="True">
                                ...
                            <VisualStateGroup x:Name="MyHighlightStates">
                                <VisualState x:Name="NotHighlightedState" />
                                <VisualState x:Name="MyHightlightedState">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="MyHighlightElement" Storyboard.TargetProperty="Visibility">
                                            <DiscreteObjectKeyFrame KeyTime="0:0:0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
            <Border x:Name="MyHighlightElement" Background="Yellow" Visibility="Collapsed"/>
        ...
        </Grid>
    </ControlTemplate >
