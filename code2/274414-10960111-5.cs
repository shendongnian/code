	public class DataContractJsonModelBinderAttribute : CustomModelBinderAttribute
	{
		public override IModelBinder GetBinder()
		{
			return new DataContractJsonModelBinder();
		}
	}
