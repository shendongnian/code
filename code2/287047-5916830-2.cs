    <sdk:DataGrid ItemsSource="{Binding MyListOfPersonItems}" AutoGenerateColumns="False">
        <sdk:DataGrid.Columns>
            <sdk:DataGridTemplateColumn>
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <local:ColumnTemplateSelector Content="{Binding Name}" />
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
            </sdk:DataGridTemplateColumn>
            <sdk:DataGridTemplateColumn>
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <local:ColumnTemplateSelector Content="{Binding Age}" />
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
            </sdk:DataGridTemplateColumn>
            <sdk:DataGridTemplateColumn>
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <local:ColumnTemplateSelector Content="{Binding IsMarried}" />
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
            </sdk:DataGridTemplateColumn>
        </sdk:DataGrid.Columns>
    </sdk:DataGrid>
