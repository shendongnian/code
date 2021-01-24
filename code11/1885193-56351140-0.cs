	<DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False">
		<DataGrid.Columns>
			
			<DataGridTemplateColumn Header = "Filter ON" Width="SizeToCells" IsReadOnly="True">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ContentControl>
							<ContentControl.Style>
								<Style TargetType = "ContentControl" >
									<Setter Property="Visibility" Value="Hidden"/>
									<Style.Triggers>
										<DataTrigger  Binding = "{Binding Path=Children[1].Tag, RelativeSource={RelativeSource AncestorType={x:Type DataGridCellsPanel}}}" Value="True">
											<Setter Property = "Visibility" Value="Visible"/>
										</DataTrigger>
									</Style.Triggers>
								</Style>
							</ContentControl.Style>
							<TextBlock Text="Content goes here" />
						</ContentControl>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
			<DataGridTemplateColumn x:Name="F_column" Header ="Select">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ToggleButton x:Name="Filter_on" Content="Switch" IsChecked="{Binding Path=Tag, RelativeSource={RelativeSource AncestorType=DataGridCell}, Mode=OneWayToSource}" />
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
	</DataGrid>
