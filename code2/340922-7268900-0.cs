	public enum ColorSection
	{
		Red,
		Green,
		Blue
	}
	
	public ColorSection GetColorSection(int rgb)
	{
		int r = rgb & 0xFF;
		int g = (rgb >> 8) & 0xFF;
		int b = (rgb >> 16) & 0xFF;
		
		return (r > g && r > b) ? ColorSection.Red : ((g > b) ? ColorSection.Green : ColorSection.Blue);
	}
