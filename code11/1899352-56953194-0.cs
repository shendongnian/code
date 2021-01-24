    <TreeView x:Name="MyTreeView">
        <TreeView.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Vertical">
                    <TreeViewItem Header="{Binding ComputerName}">
                        <TreeViewItem.Items>
                            <TreeViewItem Header="Bios">
                                <StackPanel Orientation="Vertical">
                                    <TextBlock Text="{Binding Bios.Description}"/>
                                    <TextBlock Text="{Binding Bios.Name}"/>
                                    <TextBlock Text="{Binding Bios.Version}"/>
                                </StackPanel>
                            </TreeViewItem>
                            <TreeViewItem Header="Keyboard" ItemsSource="{Binding Keyboards}">
                                <TreeViewItem.ItemTemplate>
                                    <DataTemplate>
                                        <TreeViewItem Header="{Binding DeviceID}">
                                            <TextBlock Text="{Binding Description}"/>
                                        </TreeViewItem>
                                    </DataTemplate>
                                </TreeViewItem.ItemTemplate>
                            </TreeViewItem>
                        </TreeViewItem.Items>
                    </TreeViewItem>
                </StackPanel>
            </DataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
