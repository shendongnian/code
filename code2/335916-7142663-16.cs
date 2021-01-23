	public class InfostoreProvider
	{
		static Dictionary<Guid, InfostoreBase> allSources = 
				new Dictionary<Guid,InfostoreBase>();
		public static InfostoreBase 
			GetHomeConnection(Guid CustomerKey, string HomeFeatures)
		{
			lock (allSources)
			{
				InfostoreBase RetVal;
				if (!ValidHomeKey(CustomerKey))
					throw new 
						InvalidKeyException("not valid for Home Edition");
				allSources.TryGetValue(CustomerKey, out RetVal);
				if (RetVal == null)
				{
					RetVal = new InfostoreHomeEdition();
					allSources.Add(CustomerKey, RetVal);
				}
				var ActualVersion = (InfostoreHomeEdition) RetVal;
				RetVal.SetFeatures(HomeFeatures);
				return RetVal;
			}
		}
		public static InfostoreBase 
			GetEnterpriseConnection(Guid CustomerKey, decimal BaseDiscount)
		{
			lock (allSources)
			{
				InfostoreBase RetVal;
				if (!ValidEnterpriseKey(CustomerKey))
					throw new 
						InvalidKeyException("not valid for Enterprise Edition");
				allSources.TryGetValue(CustomerKey, out RetVal);
				if (RetVal == null)
				{
					RetVal = new InfostoreHomeEdition();
					allSources.Add(CustomerKey, RetVal);
				}
				var ActualVersion = (InfostoreEnterpriseEdition) RetVal;
				RetVal.SetBaseDiscount(CostBase);
				return RetVal;
			}
		}
	}
