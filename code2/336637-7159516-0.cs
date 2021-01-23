    public static Class DtoExtensionMethods {
	public static bool IsTooOld(this SomeSpecificDto specificDto)
	{
		return specificDto.LastModified < DateTime.Now - TimeSpan.FromHours(2) ;
    }}
