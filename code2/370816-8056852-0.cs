	internal static class DataTypes
	{
		private static readonly Dictionary<Type, ADODB.DataTypeEnum> Types
			= new Dictionary<Type, ADODB.DataTypeEnum>()
			{
				{ typeof(Boolean), ADODB.DataTypeEnum.adBoolean },
				{ typeof(DateTime), ADODB.DataTypeEnum.adDate },
				// and so on...
			};
			
		public static bool TryGetAdoTypeForClrType(Type clrType, out ADODB.DataTypeEnum adoType)
		{
			return Types.TryGetValue(clrType, out adoType);
		}
	}
