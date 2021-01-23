    public class Processor : AProcessor, BProcessor
    {
        #region AProcessor Members
        public void Process(AProcessable a)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
        #region BProcessor Members
        public void Process(BProcessable a)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
        public void Process(Processable a)
        {
            Process((AProcessable)a);
            Process((BProcessable)a);
        }
    }
