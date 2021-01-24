         <Grid>
            <DataGrid ItemsSource="{Binding Words}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                    <DataGridTemplateColumn Header="Synonym and acronyms">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <ItemsControl ItemsSource="{Binding MeaningGroups}">
                                        <ItemsControl.ItemTemplate>
                                            <DataTemplate>
                                                <StackPanel Orientation="Horizontal">
                                                    <ItemsControl ItemsSource="{Binding Synonyms}">
                                                        <ItemsControl.ItemsPanel>
                                                            <ItemsPanelTemplate>
                                                                <WrapPanel/>
                                                            </ItemsPanelTemplate>
                                                        </ItemsControl.ItemsPanel>
                                                        <ItemsControl.ItemTemplate>
                                                            <DataTemplate>
                                                                <Border BorderThickness="1" BorderBrush="Black" CornerRadius="5" Margin="5 5 0 0">
                                                                <TextBlock Margin="3" Text="{Binding}"/>
                                                                </Border>
                                                            </DataTemplate>
                                                        </ItemsControl.ItemTemplate>
                                                    </ItemsControl>
                                                    <ItemsControl ItemsSource="{Binding Acronyms}">
                                                        <ItemsControl.ItemsPanel>
                                                            <ItemsPanelTemplate>
                                                                <WrapPanel/>
                                                            </ItemsPanelTemplate>
                                                        </ItemsControl.ItemsPanel>
                                                        <ItemsControl.ItemTemplate>
                                                            <DataTemplate>
                                                                <Border BorderThickness="1" BorderBrush="Black" CornerRadius="5" Background="Red" Margin="5 5 0 0">
                                                                <TextBlock Margin="3" Text="{Binding}"/>
                                                                </Border>
                                                            </DataTemplate>
                                                        </ItemsControl.ItemTemplate>
                                                    </ItemsControl>
                                                </StackPanel>
                                            </DataTemplate>
                                        </ItemsControl.ItemTemplate>
                                    </ItemsControl>
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
