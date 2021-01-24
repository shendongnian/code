    <Grid Background="#006000">
		<Button Content="clicky" Click="clicky"
				HorizontalAlignment="Left" Margin="30"/>
		<Border Background="#00FFFFFF" >
			<Border.InputBindings>
				<MouseBinding MouseAction="LeftDoubleClick "
                    Command="{Binding CommandDoubleClick}"/>
			</Border.InputBindings>
		</Border>
	</Grid>		
