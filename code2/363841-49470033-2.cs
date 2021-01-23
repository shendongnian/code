    public static SqlDbType Typecode2SqlDbType(TypeCode typecode, out bool error)
	{
		error=false;
		switch (typecode)
		{
			case TypeCode.Empty     :
				 return SqlDbType.Variant   ;
			case TypeCode.Object    :
				 return SqlDbType.Variant   ;
			case TypeCode.DBNull    :
				 return SqlDbType.Variant   ;
			case TypeCode.Boolean   :
				 return SqlDbType.Bit       ;
			case TypeCode.Char      :
				 return SqlDbType.NChar     ;
		
			case TypeCode.Byte      :
				 return SqlDbType.TinyInt   ;
			case TypeCode.Int16     :
				 return SqlDbType.SmallInt  ;
			
			case TypeCode.Int32     :
				 return SqlDbType.Int       ;
		
			case TypeCode.Int64     :
				 return SqlDbType.BigInt    ;
		
			case TypeCode.Single    :
				 return SqlDbType.Real      ;
			case TypeCode.Double    :
				 return SqlDbType.Float     ;
			case TypeCode.Decimal   :
				 return SqlDbType.Decimal   ;
			case TypeCode.DateTime  :
				 return SqlDbType.DateTime  ;
			case TypeCode.String    :
				 return SqlDbType.NVarChar  ;
			
			// can't map TypeCode.SByte  
			// can't map TypeCode.UInt16  
			// can't map TypeCode.UInt32  
			// can't map TypeCode.UInt64  
			default:
			{
				error =true;
				return SqlDbType.NVarChar;
			}
		}
	}
}
