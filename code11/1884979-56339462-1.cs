    <TabControl x:Name="tabControl"  ItemsSource="{Binding SelectedTables}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Header}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate >
            <DataTemplate >
                <Grid>
                    <DataGrid x:Name="dataGrid" AutoGenerateColumns="True" ItemsSource="{Binding Tablecontent}"/>
                </Grid>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
