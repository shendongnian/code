    class MultithreadedClass
    {
        private AtomicBoolean isUpdating = new AtomicBoolean(false);
    
        public void Update()
        {
            if (!this.isUpdating.FalseToTrue()) return;
            try
            {
                //... do update.
            }
            finally
            {
                this.isUpdating.Value = false;
            }
        }
    }
