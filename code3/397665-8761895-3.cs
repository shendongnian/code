    <DataGrid AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Name}" />
            <DataGridTextColumn Binding="{Binding Value}" />
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.ItemTemplate>
                    <DataTemplate>
                        <ItemsControl ItemsSource="{Binding Results}">
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <StackPanel Orientation="Horizontal" />
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <TextBox Width="50" Value="{Binding }" />
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </DataTemplate>
                </DataGridTemplateColumn.ItemTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
