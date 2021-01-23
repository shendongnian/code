    <Custom:DataGrid GridLinesVisibility="Vertical">
        <Custom:DataGrid.RowStyle>
            <Style TargetType="Custom:DataGridRow">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type Custom:DataGridRow}">
                            <Border x:Name="DGR_Border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                                <Custom:SelectiveScrollingGrid>
                                    <Custom:SelectiveScrollingGrid.ColumnDefinitions>
                                        <ColumnDefinition Width="Auto"/>
                                        <ColumnDefinition Width="*"/>
                                    </Custom:SelectiveScrollingGrid.ColumnDefinitions>
                                    <Custom:SelectiveScrollingGrid.RowDefinitions>
                                        <RowDefinition Height="*"/>
                                        <RowDefinition Height="Auto"/>
                                        <RowDefinition Height="Auto"/>
                                    </Custom:SelectiveScrollingGrid.RowDefinitions>
                                    <Custom:DataGridCellsPresenter Grid.Column="1" ItemsPanel="{TemplateBinding ItemsPanel}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                    <Custom:DataGridDetailsPresenter Grid.Column="1" Grid.Row="1" Visibility="{TemplateBinding DetailsVisibility}">
                                        <Custom:SelectiveScrollingGrid.SelectiveScrollingOrientation>
                                            <Binding Path="AreRowDetailsFrozen" RelativeSource="{RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Custom:DataGrid}}">
                                                <Binding.ConverterParameter>
                                                    <Custom:SelectiveScrollingOrientation>Vertical</Custom:SelectiveScrollingOrientation>
                                                </Binding.ConverterParameter>
                                            </Binding>
                                        </Custom:SelectiveScrollingGrid.SelectiveScrollingOrientation>
                                    </Custom:DataGridDetailsPresenter>
                                    <Custom:DataGridRowHeader Grid.RowSpan="2" Custom:SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical">
                                        <Custom:DataGridRowHeader.Visibility>
                                            <Binding Path="HeadersVisibility" RelativeSource="{RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Custom:DataGrid}}">
                                                <Binding.ConverterParameter>
                                                    <Custom:DataGridHeadersVisibility>Row</Custom:DataGridHeadersVisibility>
                                                </Binding.ConverterParameter>
                                            </Binding>
                                        </Custom:DataGridRowHeader.Visibility>
                                    </Custom:DataGridRowHeader>
                                    <Path Grid.Row="2" Grid.ColumnSpan="2"
                                          Data="M0,0.5 L1,0.5"
                                          Stretch="Fill" Stroke="Black" StrokeThickness="1"
                                          StrokeDashArray="1.0 2.0"/>
                                </Custom:SelectiveScrollingGrid>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Custom:DataGrid.RowStyle>
        <!-- ... -->
    </Custom:DataGrid>
 
