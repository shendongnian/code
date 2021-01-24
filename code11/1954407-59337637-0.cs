    <TreeView x:Name="MainTreeView" HorizontalAlignment="Stretch" Margin="10" VerticalAlignment="Stretch" ItemsSource="{Binding Departments}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Positions}">
                <Button Command="{Binding ElementName=MainTreeView, Path=DataContext.TreeViewCommand}" CommandParameter="{Binding DepartmentName}" BorderThickness="0" Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}" >
                    <Label Content="{Binding DepartmentName}"/>
                </Button>
                <HierarchicalDataTemplate.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding Employees}">
                        <Button Command="{Binding ElementName=MainTreeView, Path=DataContext.TreeViewCommand}" CommandParameter="{Binding PositionName}" BorderThickness="0" Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}" >
                            <Label Content="{Binding PositionName}"/>
                        </Button>
                        <HierarchicalDataTemplate.ItemTemplate>
                            <DataTemplate>
                                <Button Command="{Binding ElementName=MainTreeView, Path=DataContext.TreeViewCommand}" CommandParameter="{Binding EmployeeName}" BorderThickness="0" Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}" >
                                    <Label Content="{Binding EmployeeName}"/>
                                </Button>
                            </DataTemplate>
                        </HierarchicalDataTemplate.ItemTemplate>
                    </HierarchicalDataTemplate>
                </HierarchicalDataTemplate.ItemTemplate>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
