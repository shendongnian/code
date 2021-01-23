    public class MeaningfulClassName
    {  
        public int Val1;
        public string Val2;
        ....
    }
    public class Processor
    {
        public MeaningfulClassName MyFunction(int something, string somethingelse)
        {
            var ret = new MeaningfulClassName();
            ....
            return ret;
        }
    }
