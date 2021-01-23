    <StackPanel Background="Transparent">
		<StackPanel.ContextMenu>
			<ContextMenu ItemsSource="{Binding Path=AnotherWindow.CommandBindings}">
				<ContextMenu.ItemContainerStyle>
					<Style TargetType="{x:Type MenuItem}">
						<Setter Property="Header" Value="{Binding Path=Command.Name}" />
						<Setter Property="Command">
							<Setter.Value>
								<MultiBinding Converter="{StaticResource commandConverter}">
									<Binding />
									<Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type ContextMenu}}" />
								</MultiBinding>
    public class CommandConverter : IMultiValueConverter
	{
		public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var cb = value[0] as CommandBinding;
			var cm = value[1] as ContextMenu;
			if(cb == null || cm == null)
				return null;
			cm.CommandBindings.Add(cb);
			return cb.Command;
		}
		public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
