	public enum EQueryMode
	{
		Manual,
		Automatic
	}
	public class FieldSpecification
	{
		public string FieldName { get; set; }
		public bool[] QueryInMode { get; set; }
		public FieldSpecification
			(
				string parFieldName, 
				bool parQueryInManual, 
				bool parQueryInAutomatic
			)
		{
			FieldName = parFieldName;
			QueryInMode = new bool[] { parQueryInManual, parQueryInAutomatic };
		}
	}
	public class SomeKindOfRecord
	{
		public List<FieldSpecification> FieldInfo =
			new List<FieldSpecification>()
				{
					new FieldSpecification("Field1",  true, true),
					new FieldSpecification("Field2",  true, false),
					new FieldSpecification("Field3",  true, true),
					new FieldSpecification("Field4",  true, false)
				};
		// ...
		public void PerformQuery(EQueryMode QueryMode)
		{
			List<string> FieldsToSelect =
				(
					from f
						in FieldInfo
					where
						f.QueryInMode[(int)QueryMode]
					select
						f.FieldName
				)
				.ToList();
			Fetch(FieldsToSelect);
		}
		private void Fetch(List<string> Fields)
		{
			// SQL (or whatever) here
		}
	}
