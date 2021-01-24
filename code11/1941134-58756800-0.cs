    public class data
    {
        public type1 ParamName1 {get;set;}
        public type2 paramName2 {get;set;}
        // initalize with what ever default the method takes as optional
        public int paramName10 {get;set;} = 123; 
    }
    
    ...
    
    // pass in all paramaters, dont both about ifs
    // we can do this, because you have already figured out the defaults
    // from the signature 
    MethodA(data.ParamName1, data.paramName2, data.paramName10);
