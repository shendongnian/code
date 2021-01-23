	<ListBox.ItemContainerStyle>
		<Style TargetType="ListBoxItem">
			<Style.Triggers>
				<MultiDataTrigger>
					<MultiDataTrigger.Conditions>
						<Condition Binding="{Binding SelectedItems.Count, RelativeSource={RelativeSource AncestorType=ListBox}}" Value="5"/>
						<Condition Binding="{Binding IsSelected, RelativeSource={RelativeSource Self}}" Value="false"/>
					</MultiDataTrigger.Conditions>
					<Setter Property="IsEnabled" Value="False"/>
				</MultiDataTrigger>
			</Style.Triggers>
		</Style>
	</ListBox.ItemContainerStyle>
