	public class NonPublicPropertiesResolver : DefaultContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
			var prop = base.CreateProperty(member, memberSerialization);
			var pi = member as PropertyInfo;
			if (pi != null) {
				prop.Readable = pi.GetMethod != null;
				prop.Writable = pi.SetMethod != null;
			}
			return prop;
		}
	}
