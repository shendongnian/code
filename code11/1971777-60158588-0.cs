	public static partial class JsonExtensions
	{
		const string refPropertyName = "ref";
		
		public static void ResolveRefererences(JToken root)
		{
			if (!(root is JContainer container))
				return;
			var refs = container.Descendants().OfType<JObject>().Where(o => IsRefObject(o)).ToList();
			Console.WriteLine(JsonConvert.SerializeObject(refs));
			foreach (var refObj in refs)
			{
				var path = GetRefObjectValue(refObj);
				var original = ResolveRef(root, path);
				if (original != null)
					refObj.Replace(original);
			}
		}
		
		static bool IsRefObject(JObject obj)
		{
			return GetRefObjectValue(obj) != null;
		}
		
		static string GetRefObjectValue(JObject obj)
		{
			if (obj.Count == 1)
			{
				var refValue = obj[refPropertyName];
				if (refValue != null && refValue.Type == JTokenType.String)
				{
					return (string)refValue;
				}
			}
			return null;
		}
		static JToken ResolveRef(JToken token, string path)
		{
			// TODO: determine whether it is possible for a property name to contain a '.' character, and if so, how the path will look.
			var components = path.Split('.'); 
			
			foreach (var component in components)
			{
				if (token is JObject obj)
					token = obj[component];
				else if (token is JArray array)
					token = token[int.Parse(component, NumberFormatInfo.InvariantInfo)];
				else
					// Or maybe just return null?
					throw new JsonException("Unexpected token type.");
			}
			return token;
		}
	} 
