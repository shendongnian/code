        /// <summary>
		/// This is to prevent potential SQL worms because of SQL assembling.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static String FilterInvalidSqlChars(String str)
		{
			if(str==null || str=="")
				return str;
            String[] badChars = { "\'" };
			str = str.Replace(badChars[0], "\'\'");
			return str;
		}
		/// <summary>
		/// This function adds "'" to the begin and end of a string value so that it
		/// can be used in a SQL statement directly by + operation. It also filters the 
		/// invalid SQL characters, such as "that's ok" to --> "'That''s ok'"
		/// Note all strings are unicode strings. if strValue is null, it returns a string "null".
		/// </summary>
		public static String ToSqlStrValue(String strValue)
		{
			if(strValue==null)
				return "null";
			else 
				return "N\'" + FilterInvalidSqlChars(strValue) + '\'';
		}
