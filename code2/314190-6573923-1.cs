	<Style TargetType="{x:Type local:HeaderedSeparator}">
		<Setter Property="Template">
			<Setter.Value>
				<ControlTemplate TargetType="{x:Type local:HeaderedSeparator}">
					<Grid Height="{TemplateBinding Height}">
						<Grid.ColumnDefinitions>
							<ColumnDefinition Width="15"/>
							<ColumnDefinition Width="Auto"/>
							<ColumnDefinition />
						</Grid.ColumnDefinitions>
						<Separator Grid.Column="0"/>
						<TextBlock Grid.Column="1" 
							VerticalAlignment="Center" Margin="5 0" 
							Text="{TemplateBinding Header}"/>
						<Separator Grid.Column="2" />
					</Grid>
				</ControlTemplate>
			</Setter.Value>
		</Setter>
	</Style>
	
