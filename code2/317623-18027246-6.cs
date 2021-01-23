    class MultithreadedClass
    {
        private AtomicBoolean isUpdating = new AtomicBoolean(false);
    
        public void Update()
        {
            if (!this.isUpdating.FalseToTrue())
            {
                return; //a different thread is already updating
            }
            try
            {
                //... do update.
            }
            finally
            {
                this.isUpdating.Value = false; //we are done updating
            }
        }
    }
