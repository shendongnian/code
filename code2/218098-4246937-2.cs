    <ListView ...>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Style.Resources>
                    <!-- Foreground for Selected ListViewItem -->
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" 
                                     Color="Black"/>
                    <!-- Background for Selected ListViewItem -->
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}"
                                     Color="Transparent"/>
                </Style.Resources>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListViewItem}">
                            <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                                <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <!--<Trigger Property="IsSelected" Value="true">
                                        <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                                </Trigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="IsSelected" Value="true"/>
                                        <Condition Property="Selector.IsSelectionActive" Value="false"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
                                </MultiTrigger>-->
                                <Trigger Property="IsEnabled" Value="false">
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
        ...
    </ListView>
        
                    
