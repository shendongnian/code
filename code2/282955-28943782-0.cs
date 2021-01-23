	/// <summary>
	/// generate a random number where the likelihood of a large number is greater than the likelihood of a small number
	/// </summary>
	/// <param name="rnd">the random number generator users to spawn the number</param>
	/// <returns>the random number</returns>
	public static double InverseBellCurve(Random rnd)
	{
		return 1 - BellCurve(rnd);
	}
	/// <summary>
	/// generate a random number where the likelihood of a small number is greater than the likelihood of a Large number
	/// </summary>
	/// <param name="rnd">the random number generator users to spawn the number</param>
	/// <returns>the random number</returns>
	public static double BellCurve(Random rnd)
	{
		double rtn = rnd.NextDouble();
		return  Math.Pow(2 * rnd.NextDouble() - 1, 2);
	}
	/// <summary>
	/// generate a random number where the likelihood of a mid range number is greater than the likelihood of a Large or small number
	/// </summary>
	/// <param name="rnd">the random number generator users to spawn the number</param>
	/// <returns>the random number</returns>
	public static double HorizontalBellCurve(Random rnd)
	{
		double rtn = (Math.Sqrt(1-rnd.NextDouble())+1)/2;
		if(rnd.NextDouble()>0.5) //randomly use negative root
			return 1-rtn;
		else
			return rtn;
	}
