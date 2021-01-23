            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="local:CustomDataPoint">
                        <Grid x:Name="Root"
                              Opacity="0">
                            <ToolTipService.ToolTip>
                                <ToolTip BorderThickness="0"
                                         DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}"
                                         Background="Transparent"
                                         BorderBrush="Transparent">
                                    <ToolTip.Template>
                                        <ControlTemplate TargetType="ToolTip">
                                            <Charts:ExpensesToolTip HorizontalAlignment="Stretch"
                                                                    VerticalAlignment="Stretch" />
                                        </ControlTemplate>
                                    </ToolTip.Template>
                                </ToolTip>
                            </ToolTipService.ToolTip>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.1" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="MouseOver" />
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.1" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Unselected" />
                                    <VisualState x:Name="Selected" />
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="RevealStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.5" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Shown">
                                        <Storyboard>
                                            <DoubleAnimation Duration="0"
                                                             To="1"
                                                             Storyboard.TargetProperty="Opacity"
                                                             Storyboard.TargetName="Root" />
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Hidden">
                                        <Storyboard>
                                            <DoubleAnimation Duration="0"
                                                             To="0"
                                                             Storyboard.TargetProperty="Opacity"
                                                             Storyboard.TargetName="Root" />
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups><TextBlock Text="{TemplateBinding DependentValuesSum}"
                                       VerticalAlignment="Top" Margin="-2,-21,0,0" TextAlignment="Center"
                                   Visibility="{Binding IsTopPoint, Converter={StaticResource VisibilityConverter}, RelativeSource={RelativeSource TemplatedParent}}"
                                   HorizontalAlignment="Center" />
                        <Grid x:Name="grid"
                              Background="{TemplateBinding Background}">
                            <Grid.OpacityMask>
                                <LinearGradientBrush EndPoint="0.5,1"
                                                     StartPoint="0.5,0">
                                    <GradientStop Color="#87FFFFFF" />
                                    <GradientStop Color="#D6FFFFFF"
                                                  Offset="1" />
                                </LinearGradientBrush>
                            </Grid.OpacityMask>
                        </Grid>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>`
