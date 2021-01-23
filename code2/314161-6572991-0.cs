       public void Add(TItem item)
        {
            if (collectObject == null)
            {
                collectObject = new Collect<TItem>();
            }
            this.collectObject.Add(item);           
        }
