    <DataGrid Name="dgSafetyFunction" AutoGenerateColumns="False" ItemsSource="{Binding SafetyFunctionList}" Margin="0,0,0,45" 
              SelectedItem="{Binding Path=SelectedItem, Mode=TwoWay}" IsReadOnly="True" IsSynchronizedWithCurrentItem="True" SelectionUnit="FullRow">
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID" Binding="{Binding ID}"/>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
            <DataGridTextColumn Header="Beschreibung" Binding="{Binding Description}"/>
            <DataGridTextColumn Header="Projekt ID" Binding="{Binding ProjectID}"/>
        </DataGrid.Columns>
        <DataGrid.CellStyle>
            <Style TargetType="{x:Type DataGridCell}">
                <Setter Property="Background" Value="Transparent"/>
                <Setter Property="BorderBrush" Value="Transparent"/>
                <Setter Property="BorderThickness" Value="1"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type DataGridCell}">
                            <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                                <ContentPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                <Border.InputBindings>
                                    <MouseBinding MouseAction="LeftDoubleClick" Command="{Binding DataContext.OnDataGridDoubleClickCommand, 
                                                RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                                </Border.InputBindings>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                        <Setter Property="BorderBrush" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                    </Trigger>
                    <Trigger Property="IsKeyboardFocusWithin" Value="True">
                        <Setter Property="BorderBrush" Value="{DynamicResource {x:Static DataGrid.FocusBorderBrushKey}}"/>
                    </Trigger>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsSelected" Value="true"/>
                            <Condition Property="Selector.IsSelectionActive" Value="false"/>
                        </MultiTrigger.Conditions>
                        <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightBrushKey}}"/>
                        <Setter Property="BorderBrush" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightBrushKey}}"/>
                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightTextBrushKey}}"/>
                    </MultiTrigger>
                    <Trigger Property="IsEnabled" Value="false">
                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </DataGrid.CellStyle>
    </DataGrid>
