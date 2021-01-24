	<ContentControl Content="{Binding MainContent}">
		<ContentControl.Resources>
			<DataTemplate DataType="{x:Type vm_Type1:Type1ViewModel}">
				<vw_Type1:Type1View />
			</DataTemplate>
			<DataTemplate DataType="{x:Type vm_Type2:Type2ViewModel}">
				<vw_Type2:Type2View />
			</DataTemplate>
		</ContentControl.Resources>
	</ContentControl>
