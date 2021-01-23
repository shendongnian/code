	public class ComplexModulusComparer :
		IComparer<Complex>,
		IComparer
	{
		public static readonly ComplexModulusComparer Default = new ComplexModulusComparer();
	
		public int Compare(Complex a, Complex b)
		{
			return a.ModulusSquared().CompareTo(b.ModulusSquared());
		}
		
		int IComparer.Compare(object a, object b)
		{
			return ((Complex)a).ModulusSquared().CompareTo(((Complex)b).ModulusSquared());
		}
	}
	
