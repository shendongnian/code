    public class tester : IDisposable
    {
        #region IDisposable Members
        public void Dispose()
        {
            //cleanup code here
        }
        #endregion
    }
    using (tester t = new tester())
    {
    }
    //tester now disposed 
