	public class ComplexModulusComparator :
		IComparer<Complex>,
		IComparer
	{
		public static readonly ComplexModulusComparator Instance = new ComplexModulusComparator();
	
		public int Compare(Complex a, Complex b)
		{
			return a.ModulusSquared().CompareTo(b.ModulusSquared());
		}
		
		int IComparer.Compare(object a, object b)
		{
			return ((Complex)a).ModulusSquared().CompareTo(((Complex)b).ModulusSquared());
		}
	}
	
