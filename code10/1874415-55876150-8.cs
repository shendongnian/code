    xmlns:sys="clr-namespace:System;assembly=mscorlib"
	<ComboBox ItemsSource="{Binding Styles, Mode=OneWay}" SelectedItem="{Binding SelectedStyle}">
		<ComboBox.Resources>
			<DataTemplate DataType="{x:Type sys:String}">
				<TextBlock>
					<TextBlock.Style>
						<Style TargetType="{x:Type TextBlock}">
							<Setter Property="Text" Value="{Binding}" />
							<Style.Triggers>
								<DataTrigger Binding="{Binding}" Value="">
									<Setter Property="Text" Value="[Discard style]" />
								</DataTrigger>
							</Style.Triggers>
						</Style>
					</TextBlock.Style>
				</TextBlock>
			</DataTemplate>
		</ComboBox.Resources>
	</ComboBox>
