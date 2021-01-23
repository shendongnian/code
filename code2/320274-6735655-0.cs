    <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False" >
       <DataGrid.Columns>
            <DataGridTemplateColumn Header="Custom Column">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Button Tag="{Binding}" Content="Click Me" Click="Button_ClickHandler"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridtemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
