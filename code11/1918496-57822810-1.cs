    <TreeView Grid.Column="1" Grid.Row="1" ItemsSource="{Binding MyTree}" MaxHeight="270" ScrollViewer.VerticalScrollBarVisibility="Auto" VirtualizingStackPanel.IsVirtualizing="True">
					<i:Interaction.Behaviors>
						<h:BindableTreeViewSelectedItemBehavior SelectedItem="{Binding SelectedTV}"></h:BindableTreeViewSelectedItemBehavior>
					</i:Interaction.Behaviors>
					<TreeView.ItemTemplate>
						<HierarchicalDataTemplate ItemsSource="{Binding Children}" DataType="{x:Type wiz:TVTest}">
							<Label Content="{Binding Name}"></Label>
							<HierarchicalDataTemplate.ItemTemplate>
								<HierarchicalDataTemplate ItemsSource="{Binding Children}" DataType="{x:Type wiz:TVTest}">
									<Label Content="{Binding Name}"></Label>
									<HierarchicalDataTemplate.ItemTemplate>
										<DataTemplate DataType="{x:Type wiz:TVTest}">
											<Label Content="{Binding Name}"></Label>
										</DataTemplate>
									</HierarchicalDataTemplate.ItemTemplate>
								</HierarchicalDataTemplate>
							</HierarchicalDataTemplate.ItemTemplate>
						</HierarchicalDataTemplate>
					</TreeView.ItemTemplate>
				</TreeView>
