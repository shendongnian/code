	<DataGrid ItemsSource="{Binding Users}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Id}" Header="Id"/>
                <DataGridTextColumn Binding="{Binding UserName}" Header="UserName"/>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="View" cal:Message.Attach="[Event Click]=[ViewUser($dataContext)]"></Button>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
