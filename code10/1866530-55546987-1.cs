	public class Complex
	{
	    public double Real { get; set; }
	    public double Imaginary { get; set; }
	
		public static Complex operator *(Complex a, Complex b) =>
			new Complex()
			{
				Real = a.Real * b.Real - a.Imaginary * b.Imaginary,
				Imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real,
			};
		
		public static Complex Conjugate(Complex a) =>
				new Complex() { Real = a.Real, Imaginary = -a.Imaginary };
		
		public static Complex operator /(Complex a, double b) =>
				new Complex() { Real = a.Real / b, Imaginary = a.Imaginary / b };
		
		public static Complex operator /(Complex a, Complex b) =>
				a * Conjugate(b) / (b * Conjugate(b)).Real;
	}
