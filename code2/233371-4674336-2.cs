            <data:DataGrid.Columns>
                <data:DataGridTextColumn Header="First Name" Binding="{Binding FName}" >
                    <data:DataGridTextColumn.HeaderStyle>
                        <Style TargetType="dataprimitives:DataGridColumnHeader">
                            <Setter Property="ContentTemplate">
                                <Setter.Value>
                                    <DataTemplate>
                                        <ContentControl Content="{Binding}">
                                            <ToolTipService.ToolTip>
                                                <ToolTip Content="Tooltip First" />
                                            </ToolTipService.ToolTip>
                                        </ContentControl>
                                    </DataTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </data:DataGridTextColumn.HeaderStyle>
                </data:DataGridTextColumn>
                <data:DataGridTextColumn Header="Last Name" Binding="{Binding LName}">
                    <data:DataGridTextColumn.HeaderStyle>
                        <Style TargetType="dataprimitives:DataGridColumnHeader">
                            <Setter Property="ContentTemplate">
                                <Setter.Value>
                                    <DataTemplate>
                                        <ContentControl Content="{Binding}">
                                            <ToolTipService.ToolTip>
                                                <ToolTip Content="Tooltip Second"></ToolTip>
                                            </ToolTipService.ToolTip>
                                        </ContentControl>
                                    </DataTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </data:DataGridTextColumn.HeaderStyle>
                </data:DataGridTextColumn>
                <data:DataGridTextColumn Header="City" Binding="{Binding City}">
                    <data:DataGridTextColumn.HeaderStyle>
                        <Style TargetType="dataprimitives:DataGridColumnHeader">
                            <Setter Property="ContentTemplate">
                                <Setter.Value>
                                    <DataTemplate>
                                        <ContentControl Content="{Binding}">
                                            <ToolTipService.ToolTip>
                                                <ToolTip Content="Tooltip Third"></ToolTip>
                                            </ToolTipService.ToolTip>
                                        </ContentControl>
                                    </DataTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </data:DataGridTextColumn.HeaderStyle>
                </data:DataGridTextColumn>
            </data:DataGrid.Columns>
        </data:DataGrid>
    </Grid>
