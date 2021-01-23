	public class Metadata<T>
	{
		private Dictionary<string, Metadata<T>> _properties = new Dictionary<string, Metadata<T>>();
		private MethodInfo _getter;
		private void BuildMetadata()
		{
			Type t = typeof (T);
			foreach (PropertyInfo propertyInfo in t.GetProperties())
			{
				// ....
			}
		}
	}
