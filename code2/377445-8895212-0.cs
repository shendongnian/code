	/// <summary>
	/// Returns the bit depth of <paramref name="image"/>.
	/// </summary>
	public static int GetBitDepth(this Image image)
	{
		return ((int) image.PixelFormat >> 8) & 0xFF;
	}
