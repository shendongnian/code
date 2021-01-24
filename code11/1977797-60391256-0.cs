    public class MyElement : BaseElement
    {  
        public enum Types { Type1, Type2, Type3, Type4}
        public Dictionary<Types, string> AllTypes = new Dictionary<Types, string>()
        {
            { Types.Type1, "Value 1" },
            { Types.Type2, "Value 2" },
            { Types.Type3, "Value 3" },
            { Types.Type4, "Value 4" },
        };
		public enum Category { Category1, Category2, Category3, Category4}
        public Dictionary<Category, string> Categories = new Dictionary<Category, string>()
        {
            { Category.Category1, "Value 1" },
            { Category.Category2, "Value 2" },
            { Category.Category3, "Value 3" },
            { Category.Category4, "Value 4" },
        };
		public MyElement(Types type, Category category)
		{
			type = AllTypes[type];
			category = Categories[category];
		}
	}
	public class Test
	{
		[Test, Pairwise]
        public void ValidBaseCheckElementCalls
		(
			[Values(Types.Type1, Types.Type2, Types.Type3, Types.Type4)] Types objType,
			[Values(Category.Category1, Category.Category2, Category.Category3, Category.Category4)] Category objCategory,
		)
		
		{
			MyElement element = new MyElement(objType, objCategory);
		}
	
	}
