    <Button Name="AddRangeBtn" Height="50" Width="50" Margin="5" 
                        Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType={x:Type StackPanel}}}"
                        controls:OpenContextMenuOnLeftClickBehavior.IsEnabled="True">
                    <Button.Content>
                        <Image Source="{StaticResource DmxPlusIconImage}" 
                               HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
                               MaxHeight="50" MaxWidth="50" Margin="-10" />
                    </Button.Content>
                    <Button.ToolTip>
                        <ToolTip Style="{DynamicResource DMXToolTipStyle}"
                                 Content="{x:Static Localization:StringResources.AddFrequencyRangeTooltip}"/>
                    </Button.ToolTip>
                    <Button.ContextMenu>
                        <ContextMenu Name="AddRngContextMenu" 
                                     DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                            <MenuItem Style="{StaticResource localMenuItem}"
                                      IsEnabled="{Binding CanAddLinearRange}">
                                <MenuItem.ToolTip>
                                    <ToolTip Style="{DynamicResource DMXToolTipStyle}"
                                         Content="{x:Static Localization:StringResources.ToolTip_AddLinearFrequencyRange}"/>
                                </MenuItem.ToolTip>
                                <MenuItem.Header>
                                    <Button>
                                        <Image Source="{StaticResource DMXAddLinFreqRngTypeIconImage}" MinHeight="37" MinWidth="37"/>
                                    </Button>
                                </MenuItem.Header>
                            </MenuItem>
