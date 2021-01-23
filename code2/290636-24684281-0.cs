    <ListBox.ItemContainerStyle>                
        <Style TargetType="ListBoxItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListBoxItem">
                        <StackPanel>
                            <Separator x:Name="Separator"/>
                            <ContentPresenter/>
                        </StackPanel>
                        <ControlTemplate.Triggers>
                            <DataTrigger Binding="{Binding RelativeSource={RelativeSource PreviousData}}" Value="{x:Null}">
                                <Setter Property="Visibility" TargetName="Separator" Value="Collapsed"/>
                            </DataTrigger>
                        </ControlTemplate.Triggers>
                        
                        <!-- Original Triggers -->
                        <Trigger Property="Selector.IsSelected" Value="True">
                            <Setter TargetName="Bd" Property="Panel.Background" 
                                    Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                            <Setter Property="TextElement.Foreground"
                                    Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                        </Trigger>
                        
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="Selector.IsSelected" Value="True" />
                                <Condition Property="Selector.IsSelectionActive" Value="False"/>
                            </MultiTrigger.Conditions>
                            <Setter TargetName="Bd" Property="Panel.Background"
                                    Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}" />
                            <Setter Property="TextElement.Foreground"
                                    Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
                        </MultiTrigger>
                        
                        <Trigger Property="UIElement.IsEnabled" Value="False">
                            <Setter Property="TextElement.Foreground"
                                    Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                        </Trigger>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ListBox.ItemContainerStyle>
