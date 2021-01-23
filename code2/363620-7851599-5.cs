	public static void SortByModulus(this Complex[] array)
	{
		Array.Sort(array, ComplexModulusComparator.Instance);
	}
	public static void SortReverseByModulus(this Complex[] array)
	{
		Array.Sort(array, ComplexModulusReverseComparator.Instance);
	}
