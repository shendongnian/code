	public class Config{
		public string MyProperty1{ get; set; }
		
		private List<int> myProperty2{ get; set; } ;
		public List<int> MyProperty2{ 
			get{
				if (myProperty2 == null)
					myProperty2 = new List<int> { 4, 5, 6 };
					
				return  myProperty2 ;
			} 
			set{
				myProperty2 = value;
			} 
		} 
	}
