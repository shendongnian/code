		internal static void HandleCustomServiceName(ServiceBase sbase)
		{
			if (!string.IsNullOrWhiteSpace(customInstanceName))
			{
				sbase.ServiceName = sbase.ServiceName + "-" + customInstanceName;
			}
		}
