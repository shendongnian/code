	/// <summary>
	/// generate a random number where the likelihood of a large number is greater than the likelihood of a small number
	/// </summary>
	/// <param name="rnd">the random number generator used to spawn the number</param>
	/// <returns>the random number</returns>
	public static double InverseBellCurve(Random rnd)
	{
		return 1 - BellCurve(rnd);
	}
	/// <summary>
	/// generate a random number where the likelihood of a small number is greater than the likelihood of a Large number
	/// </summary>
	/// <param name="rnd">the random number generator used to spawn the number</param>
	/// <returns>the random number</returns>
	public static double BellCurve(Random rnd)
	{
		return  Math.Pow(2 * rnd.NextDouble() - 1, 2);
	}
	/// <summary>
	/// generate a random number where the likelihood of a mid range number is greater than the likelihood of a Large or small number
	/// </summary>
	/// <param name="rnd">the random number generator used to spawn the number</param>
	/// <returns>the random number</returns>
	public static double HorizontalBellCurve(Random rnd)
	{
		//This is not a real bell curve as using the cube of the value but approximates the result set
		return  (Math.Pow(2 * rnd.NextDouble() - 1, 3)/2)+.5;
	}
	
