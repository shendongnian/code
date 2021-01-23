    public void NonProxyableMemberNotification(Type type, System.Reflection.MemberInfo memberInfo)
		{
			if (memberInfo.DeclaringType != typeof(object))
			{
				string message = string.Format("Non-proxyable member encountered - {0} (type - {1})",
					memberInfo.Name, type.FullName);
				throw new InvalidOperationException(message);
			}
		}
