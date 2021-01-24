    <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:StatisticsValue">
                    <Border x:Name="Part_Border">
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="MyCommonStates">
                                <VisualState x:Name="MyNormal"/>
                                <VisualState x:Name="MyPointerOver">
                                    <VisualState.Setters>
                                        ...
                                    </VisualState.Setters>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
						
						...
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    <Grid x:Name="Root" Background="Transparent">
        
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="MyCommonStates">
                <VisualState x:Name="MyNormal"/>
                <VisualState x:Name="MyPointerOver">
                    <VisualState.Setters>
                        ...
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
		</VisualStateManager.VisualStateGroups>
		
		...
		</Grid>
