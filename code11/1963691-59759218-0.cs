        public class ResponseMessage
        {
    	    public string Code { get; set; }
    	    public string Msg { get; set; }
    	    public Person[] Data { get; set; }
    	    
            public bool ShouldSerializeData()
            {
                // Privileger.GetPrivilege() is a naive example of a method 
                // that gets you privilige level
                return Privileger.GetPrivilege() > 1;
            }
        }
