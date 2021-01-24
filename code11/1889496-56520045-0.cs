	public class SampleViewModel
	{
		public string Name {get; set;}
		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
		public double Price {get; set;}
		
	}
