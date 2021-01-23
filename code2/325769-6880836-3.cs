    abstract class ResultWrapper
    {
        //meta info, such as error references/properties/flags/statistics
        public ResultWrapper([meta info])
        {
            //set meta info
        }
    }
    class ResultList<T> : ResultWrapper
    {
        public readonly List<T> resultList;
        //constructor for resultList, plus meta information for parent
        public ResultList(List<T> resultList, [additional args for meta info]) : base([meta info])
        {
            this.resultList = resultList;
        }
    }
    
    class SingleResult<T> : ResultWrapper
    {
        public readonly T result;
        //constructor similar to above
    }
