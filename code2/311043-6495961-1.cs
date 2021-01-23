	public int upperThreshold { get; set; }
	public int lowerThreshold { get; set; }
	
	public string lowImage { get; set; }
	public string middleImage { get; set; }
	public string highImage { get; set; }
	
	public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is double)
			{
				if ((double)value < lowerThreshold)
				{
					//red
					return lowImage;
				}
				else if ((double)value > upperThreshold)
				{
					//green
					return highImage;
				}
				else
				{
					//amber
					return middleImage;
				}
			}
			return "Error";
		}
		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return "Not Possible";
		}
	}
	
	<local:RangeToImageConverter
		x:Name="MyRangeConverter"
		upperThreshold="30"
		lowerThreshold="50"
		lowImage="/red32.png"
		middleImage="/amber32.png"
		highImage="/green32.png"
		/>
		
