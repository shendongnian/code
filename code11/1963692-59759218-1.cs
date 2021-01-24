        public class PrivilegeContractResolver : DefaultContractResolver
        {
            public int privilege = -1;
    	    public PrivilegeContractResolver(int privilege)
    	    {
    		    this.privilege = privilege;
    	    }
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
    		    if (property.PropertyName == "Data")
    		    {
    			    property.ShouldSerialize = dummy => privilege > 1;
    		    }
                return property;
            }
        }
