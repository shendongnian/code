    public class Owner
    {
        // snip
        private BigAllocation _bigAllocation;
        // snip
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_bigAllocation != null)
                {
                    _bigAllocation.Dispose();
                    _bigAllocation = null;
                }
            }
        }
    }
