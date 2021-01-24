	public static async Task<T> GetObjectFromJson<T>(string section)
	{
		JProperty token = await FindTokenWithSectionName(section);
		return token.Value.ToObject<T>(); // What to do if token is null?
	}
	public static async Task<List<T>> GetCollection<T>(string section)
	{
		JProperty token = await FindTokenWithSectionName(section);
		return token.Value.ToObject<List<T>>(); // What to do if token is null?
	}
