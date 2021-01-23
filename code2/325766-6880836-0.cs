    abstract class ResultWrapper
    {
        //error references/properties/flags
    }
    class ResultList<T> : ResultWrapper
    {
        public readonly List<T> resultList;
        //constructor for resultList, plus meta information for parent
    }
    
    class SingleResult<T> : ResultWrapper
    {
        public readonly T result;
        //etc.
    }
        
