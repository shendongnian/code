	<TreeView.ItemTemplate>
		<HierarchicalDataTemplate ItemsSource="{Binding SubOrganLocations}">
			<StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding OrganDisplayName}" />
                    <!-- If the fields to bind to can be exposed via a collection:
                    <ItemsControl ItemsSource="{Binding Fields}"> -->
                    <ItemsControl ItemsSource="{Binding, Converter={StaticResource SomeCleverConverter}}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Orientation="Horizontal" />
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBox Text="{Binding Value}" Width="35" />
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </StackPanel>
		</HierarchicalDataTemplate>
	</TreeView.ItemTemplate>
