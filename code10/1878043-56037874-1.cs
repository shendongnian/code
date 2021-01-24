	public class ClassModel
    {
        public string ClassLevelProperty { get; set; }
		
		public string FirstNestedProperty => NestedModel.FirstNestedProperty;
		public string AnotherNestedProperty => NestedModel.AnotherNestedProperty;
		
        public NestedModel NestedModel { get; set; }
    }
