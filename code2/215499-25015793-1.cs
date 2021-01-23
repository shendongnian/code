		public static Type GetMonoType(this TypeReference type)
		{
			return Type.GetType(type.GetReflectionName(), true);
		}
		private static string GetReflectionName(this TypeReference type)
		{
			if (type.IsGenericInstance)
			{
				var genericInstance = (GenericInstanceType)type;
				return string.Format("{0}.{1}[{2}]", genericInstance.Namespace, type.Name, String.Join(",", genericInstance.GenericArguments.Select(p => p.GetReflectionName()).ToArray()));
			}
			return type.FullName;
		}
