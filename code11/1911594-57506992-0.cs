    <DataGrid Name="Test" AutoGenerateColumns="False"  ItemsSource="{Binding MyList}">
            <DataGrid.Columns >
                <DataGridTemplateColumn Header="Name">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ContentControl Content="{Binding MyControl}"  />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
