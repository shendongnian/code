    public class Parameters
	{
		[JsonProperty("bar_diameter")]
		public float bar_diameter;
		[JsonProperty("core_height")]
		public float core_height;
		[JsonProperty("roughing_offset")]
		public float roughing_offset;
		public Parameters(float barD, float coreH, float roughingO)
		{
			bar_diameter = barD;
			core_height = coreH;
			roughing_offset = roughingO;
		}
	}
