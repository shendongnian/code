        /// <summary>
    	/// Test DBValue for DBNull and return NullReplaceValue if DBValue is DBNull
    	/// </summary>
    	/// <returns>Returns NullReplaceValue if DBValue is DBNull</returns>
    	public static string NullStr(object DBValue, string NullReplaceValue)
    	{
    		if (object.ReferenceEquals(DBValue, DBNull.Value)) {
    			return NullReplaceValue;
    		} else {
    			return Convert.ToString(DBValue);
    		}
    	}
