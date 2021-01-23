    <local:TabControlEx>
        <TabItem Header="Test1">
            <DataGrid ItemsSource="{Binding Test}">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding TestValue}" Header="Test" />
                </DataGrid.Columns>
            </DataGrid>
        </TabItem>
        <TabItem Header="Test2">
            <DataGrid ItemsSource="{Binding Test}">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding TestValue}" Header="Test" />
                </DataGrid.Columns>
            </DataGrid>
        </TabItem>
    </local:TabControlEx>
