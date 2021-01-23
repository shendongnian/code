    public static class TypeEx
	{
        public static string GetTypeName(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (!type.IsGenericType)
                return type.GetNestedTypeName();
            StringBuilder stringBuilder = new StringBuilder();
            _buildClassNameRecursiv(type, stringBuilder);
            return stringBuilder.ToString();
        }
        private static void _buildClassNameRecursiv(Type type, StringBuilder classNameBuilder, int genericParameterIndex = 0)
        {
            if (type.IsGenericParameter)
                classNameBuilder.AppendFormat("T{0}", genericParameterIndex + 1);
            else if (type.IsGenericType)
            {
                classNameBuilder.Append(GetNestedTypeName(type) + "[");
                int subIndex = 0;
                foreach (Type genericTypeArgument in type.GetGenericArguments())
                {
                    if (subIndex > 0)
                        classNameBuilder.Append(":");
                    _buildClassNameRecursiv(genericTypeArgument, classNameBuilder, subIndex++);
                }
                classNameBuilder.Append("]");
            }
            else
                classNameBuilder.Append(type.GetNestedTypeName());
        }
		
        public static string GetNestedTypeName(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (!type.IsNested)
                return type.Name;
			
			StringBuilder nestedName = new StringBuilder();
			while(type != null)
		    {
				if(nestedName.Length>0)
					nestedName.Insert(0,'.');
				
				nestedName.Insert(0, _getTypeName(type));
		
				type = type.DeclaringType;
			}
			return nestedName.ToString();
        }
		
		private static string _getTypeName(Type type)
	    {
			return type.IsGenericType ? type.Name.Split('`')[0]: type.Name;
		}
	}
