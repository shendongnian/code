    public void SomeDataFunction() {	
    	ArrayList params = GetParameters(someEntity);
    	CommandObject.Parameters.AddRange(parameters.ToArray());
    }
    
    public static ArrayList GetParameters(ISomeEntity entity) {
    	ArrayList result = new ArrayList {   				
    			OleDbUtility.NewDbParam("@Param1", OleDbType.Integer, , entity.Parameter1),
    			OleDbUtility.NewDbParam("@Param2", OleDbType.VarChar, 9, entity.Parameter2),
    		}
    }
    
    public static OleDbParameter NewDbParam(string parameterName, OleDbType dataType,
    					int size, object value) {
    	OleDbParameter result = new OleDbParameter(parameterName, dataType, size, string.Empty);
    	result.Value = value;
    	return result;
    }
