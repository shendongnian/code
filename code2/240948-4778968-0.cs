    /// <summary>
    /// Represents an HSL color, composed of individual
    /// Hue, Saturation, and Lightness attributes.
    /// </summary>
    public struct HSLColor
    {
    	private int _hue;
    	private int _saturation;
    	private int _lightness;
    
    	/// <summary>
    	/// The hue attribute of the color.
        /// (This is a value, in degrees, from 0 to 360.)
    	/// </summary>
    	public int Hue
    	{
    		get { return _hue; }
    	}
    
    	/// <summary>
    	/// The saturation attribute of the color.
        /// (This is a percentage between 0 and 100.)
    	/// </summary>
    	public int Saturation
    	{
    		get { return _saturation; }
    	}
    
    	/// <summary>
    	/// The lightness attribute of the color.
        /// (This is a percentage between 0 and 100.)
    	/// </summary>
    	public int Lightness
    	{
    		get { return _lightness; }
    	}
    }
