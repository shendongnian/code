	[DataContract]
	public class MyObject {
		Int32 _Numerator;
		Int32 _Denominator;
		public MyObject(Int32 numerator, Int32 denominator) {
			_Numerator = numerator;
			_Denominator = denominator;
		}
		public Int32 Numerator {
			get { return _Numerator; }
			set { _Numerator = value; }
		}
		public Int32 Denominator {
			get { return _Denominator; }
			set { _Denominator = value; }
		}
		[DataMember(Name="Frac")]
		public String Fraction {
			get { return _Numerator + "/" + _Denominator; }
			set {
				String[] parts = value.Split(new char[] { '/' });
				_Numerator = Int32.Parse(parts[0]);
				_Denominator = Int32.Parse(parts[1]);
			}
		}
	}
