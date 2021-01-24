	namespace SO60283924
	{
		public class SomeViewModel : ANotifyPropertyChanged
		{
			private string someString;
			private int someInt;
			private object someObject;
			private decimal someDecimal;
			private object somePropertyNotPartOfValidation;
			public string SomeString { get => someString; set => SetProperty(ref someString, value); }
			public int SomeInt { get => someInt; set => SetProperty(ref someInt, value); }
			public object SomeObject { get => someObject; set => SetProperty(ref someObject, value); }
			public decimal SomeDecimal { get => someDecimal; set => SetProperty(ref someDecimal, value); }
			public object SomePropertyNotPartOfValidation { get => somePropertyNotPartOfValidation; set => SetProperty(ref somePropertyNotPartOfValidation, value); }
		}
	}
