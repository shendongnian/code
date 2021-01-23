	public Brush TabItemBrush
	{
		get
		{
			return IsContentSet ?  (Brush)UIUtilities.GetValueFromStyle(typeof(TabItem), Control.BackgroundProperty) : Brushes.LightSkyBlue;
		}
	}
	<TabItem Header="Some Header" Background="{Binding TabItemBrush, Mode=OneWay}">
