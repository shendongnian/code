       static void TypeCodeToSqlDbType()
        {
            var array = (TypeCode[])Enum.GetValues(typeof(TypeCode));
            Console.WriteLine("{0,-10}{1,-10}", "TypeCode", "SqlDbType");
            Console.WriteLine(new string('=', 40));
            foreach (var o in array)
            {
                var dbType = Parameter.ConvertTypeCodeToDbType(o); //from System.Web
				var error =true;
                var sqldbType = DbType2SqlDbType(dbType, out  error);
                if (!error)
                    Console.WriteLine("TypeCode.{0,-10} | SqlDbType.{1,-10}", o, sqldbType);
            }
        }
	
	  static SqlDbType DbType2SqlDbType(DbType dbType, out bool error)
        {
            error = true;
            SqlDbType sqlDbType = SqlDbType.NVarChar; //default for  not existing DbType
            SqlParameter parameter = new SqlParameter();
            try
            {
                parameter.DbType = dbType;
                sqlDbType = parameter.SqlDbType;
                error = false;
            }
            catch 
            {
                // can't map
                Console.WriteLine("**** can't map DbType.{0}  ***", dbType);
            }
            return sqlDbType;
        }            
			
			
