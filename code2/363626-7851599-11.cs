	public struct Complex :
		IComparable<Complex>
	{
		public double R;
		public double I;
		
		public double Modulus() { return Math.Sqrt(R * R + I * I); }
		
		public double ModulusSquared() { return R * R + I * I; }
		
		public int CompareTo(Complex other)
		{
			return this.ModulusSquared().CompareTo(other.ModulusSquared());
		}
	}
	
