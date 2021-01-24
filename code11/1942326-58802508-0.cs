    <MenuItem Header="Action" FontFamily="Open Sans" FontSize="14" HorizontalContentAlignment="Right" Foreground="White" x:Name="miAction" 
                      Margin="5" Background="#FF166FC4" Tag="{Binding}">
        <MenuItem.Style>
            <Style TargetType="{x:Type MenuItem}">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Click">
                        <EventTrigger.Actions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="ContextMenu.IsOpen">
                                        <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="True"/>
                                    </BooleanAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </Style.Triggers>
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <MenuItem Header="Remove Group"
                                              cal:Action.TargetWithoutContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"
                                              cal:Message.Attach="RemoveClicked()" />
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </MenuItem.Style>
    </MenuItem>
