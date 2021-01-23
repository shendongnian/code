               <DataGrid ItemsSource="{Binding Items,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" >
                <DataGrid.Columns>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <ContentControl x:Name="content" Content="{Binding}" >
                                </ContentControl>
                                <DataTemplate.Triggers>
                                    <DataTrigger Binding="{Binding ItemType}" Value="0">
                                        <Setter TargetName="content" Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <CheckBox IsChecked="{Binding Value,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"></CheckBox>
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </DataTrigger>
                                    <DataTrigger Binding="{Binding ItemType}" Value="1">
                                        <Setter TargetName="content" Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <TextBox Text="{Binding Value,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"></TextBox>
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </DataTrigger>
                                </DataTemplate.Triggers>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
