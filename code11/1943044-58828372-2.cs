    <TreeView ItemsSource="{Binding Items}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Features}">
                <TextBlock Text="{Binding ID}"/>
                <HierarchicalDataTemplate.ItemTemplate>
                    <DataTemplate>
                        <CheckBox Content="{Binding Name}" IsChecked="{Binding IsSelected}"/>
                    </DataTemplate>
                </HierarchicalDataTemplate.ItemTemplate>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
