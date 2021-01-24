	<ContextMenu.ItemContainerStyle>
		<Style TargetType="MenuItem">
			<Setter Property="behaviors:Attach.InputBindings">
				<Setter.Value>
					<InputBindingCollection>
						<MouseBinding Gesture="LeftClick" Command="{Binding LeftClickCommand}" />
						<MouseBinding Gesture="RightClick" Command="{Binding RightClickCommand}" />
					</InputBindingCollection>
				</Setter.Value>
			</Setter>
		</Style>
	</ContextMenu.ItemContainerStyle>
