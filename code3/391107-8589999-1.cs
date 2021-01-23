    class ImageToCanvasConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return -(int)value / 2;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		// Two-way binding not supported
    		throw new InvalidOperationException(); 
    	}
    }
    <Grid.Resources>
        <myAssembly:ImageToCanvasConverter x:Key="imageToCanvasConverter" />
    	<DataTemplate ...>
            <Image Canvas.Left="{Binding Path=Width, Converter={StaticResource imageToCanvasConverter}, Mode=OneTime}"
                   Canvas.Top="{Binding Path=Height, Converter={StaticResource imageToCanvasConverter}, Mode=OneTime}"
                   ... />
        </DataTemplate>
    </Grid.Resources>
