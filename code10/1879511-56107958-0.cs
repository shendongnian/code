    <TreeView ItemsSource="{Binding Branches}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Branches}">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition></ColumnDefinition>
                        <ColumnDefinition></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <TextBox Grid.Column="0" Text="{Binding Id}"></TextBox>
                    <TextBox Grid.Column="1" Text="{Binding Name}"></TextBox>
                </Grid>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
