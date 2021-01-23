    <UserControl.Resources>
        <sdk:HierarchicalDataTemplate x:Key="treeNodeTemplate" 
                                      ItemsSource="{Binding Children}">
            <ContentControl Content="{Binding}">
                <ContentControl.Resources>
                    <DataTemplate DataType="ViewModels:Folder">
                        <TextBlock Text="{Binding FolderName}" />
                    </DataTemplate>
                    <DataTemplate DataType="ViewModels:Song">
                        <Image Source="{Binding PictureSource}" />
                    </DataTemplate>
                    ...
                </ContentControl.Resources>
            </ContentControl>
        </sdk:HierarchicalDataTemplate>
    </UserControl.Resources>
    	
    <sdk:TreeView ItemsSource="{Binding Roots, Mode=OneWay}"
    			  ItemTemplate="{StaticResource treeNodeTemplate}"/>
