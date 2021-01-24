    public class EnumTranslatorService:IEnumTranslatorService
	{
		private IModelMetadataProvider _metadataProvider;
		public EnumTranslatorService(IModelMetadataProvider metadataProvider)
		{
			_metadataProvider = metadataProvider;
		}
		public string TranslateDisplayName<TEnum>(TEnum e) where TEnum : struct
		{
			var a = _metadataProvider.GetMetadataForType(e.GetType());
			var name = a.EnumGroupedDisplayNamesAndValues.FirstOrDefault(t => 
                           t.Value ==  a.EnumNamesAndValues[e.ToString()]).Key.Name;
			return name ?? e.ToString();
		}
	}
