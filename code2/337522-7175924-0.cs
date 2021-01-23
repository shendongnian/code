	public class LocalizedDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
	{
	    private static readonly Type _i18nType = I18nTypeProvider.GetI18nType();
	    
	    private static void GetLocalizedDisplayName(ModelMetadata meta, string propertyName)
	    {
	        ResourceManager rm = new ResourceManager(_i18nType);
	        CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
	        string resource = string.Format("{0}_{1}", meta.ContainerType.Name, meta.PropertyName).ToLower();
	        meta.DisplayName = rm.GetString(resource, culture);
	    }
	}
