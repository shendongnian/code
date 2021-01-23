    public class Consumer
    {
        private LockProvider provider;
        public void DoStufOnFile(string fileName)
        {
            using (this.provider.Enter(fileName))
            {
                // Long running operation on file here.
            }
        }
    }
