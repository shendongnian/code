    public class DtoDefinitionAttribute:Attribute
    {
    	
        public DtoDefinitionAttribute(int order)=>Order = order;
    	public DtoDefinitionAttribute(int order,bool isJson,Type jsonDataType)
    	{
    		Order = order;
    		JsonDataType = jsonDataType;
    		IsJson = isJson;
    	}
    	public bool IsJson{get;} = false;
        public int Order{get;}
    	public Type JsonDataType {get;}
    }
