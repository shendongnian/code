    private static SqlDbType ConvertSqlTypeEnum(SqlDataType sqlDataType)
    		{
    			SqlDbType sqlDbType;
    			switch (sqlDataType)
    			{
    				case SqlDataType.UserDefinedType:
    					sqlDbType = System.Data.SqlDbType.Udt;
    					break;
    				case SqlDataType.None:
    				case SqlDataType.NVarCharMax:
    				case SqlDataType.UserDefinedDataType:
    				case SqlDataType.VarBinaryMax:
    				case SqlDataType.VarCharMax:
    				case SqlDataType.SysName:
    				case SqlDataType.Numeric:
    				case SqlDataType.UserDefinedTableType:
    				case SqlDataType.HierarchyId:
    				case SqlDataType.Geometry:
    				case SqlDataType.Geography:
    					throw new NotSupportedException("Unable to convert to SqlDbType:" + sqlDataType);
    				default:
    					sqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlDataType.ToString());
    					break;
    			}
    			return sqlDbType;
    		}
