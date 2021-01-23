				public static string GetFriendlyTypeName(Type type)
				{
					string friendlyName = type.Name;
					if (type.IsGenericType)
					{
						int iBacktick = friendlyName.IndexOf('`');
						if (iBacktick > 0)
						{
							friendlyName = friendlyName.Remove(iBacktick);
						}
						friendlyName += "<";
						Type[] typeParameters = type.GetGenericArguments();
						for (int i = 0; i < typeParameters.Length; ++i)
						{
							string typeParamName = GetFriendlyTypeName(typeParameters[i]);
							friendlyName += (i == 0 ? typeParamName : "," + typeParamName);
						}
						friendlyName += ">";
						friendlyName = "global::" + type.Namespace + "." + friendlyName;
					}
					else
					{
						friendlyName = "global::" + type.FullName;
					}
					return friendlyName.Replace('+', '.');
				}
