    	public class LocalizedDataAnnotationsModelMetadataProvider<T> : DataAnnotationsModelMetadataProvider
	{
		protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType,
		                                                Func<object> modelAccessor, Type modelType, string propertyName)
		{
			var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
			if (string.IsNullOrWhiteSpace(propertyName))
				return meta;
			if (meta.DisplayName == null)
				GetLocalizedDisplayName<T>(meta, propertyName);
			if (string.IsNullOrWhiteSpace(meta.DisplayName))
			{
				string resource = string.Format("{0}_{1}", meta.ContainerType.Name, meta.PropertyName).ToLower();
				meta.DisplayName = string.Format("[{0}]", resource);
			}
			return meta;
		}
		private static void GetLocalizedDisplayName<T>(ModelMetadata meta, string propertyName)
		{
			ResourceManager rm = new ResourceManager(typeof (T));
			CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
			string resource = string.Format("{0}_{1}", meta.ContainerType.Name, meta.PropertyName).ToLower();
			meta.DisplayName = rm.GetString(resource, culture);
		}
