    <TreeView.ItemTemplate>
        <HierarchicalDataTemplate ItemsSource="{Binding FeaturesIsChecked}">
            <TextBlock Text="{Binding ID}"/>
            <HierarchicalDataTemplate.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding Name}" 
                              IsChecked="{Binding IsSelected}"/>
                </DataTemplate>
            </HierarchicalDataTemplate.ItemTemplate>
        </HierarchicalDataTemplate>
    </TreeView.ItemTemplate>
