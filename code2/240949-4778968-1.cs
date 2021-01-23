    /// <summary>
    /// Returns the "(HH, SS, LL)" representation of this HSLColor structure.
    /// </summary>
    public override string ToString()
    {
    	return string.Format("({0}, {1}, {2})",
                             this.Hue,
                             this.Saturation,
                             this.Lightness);
    }
