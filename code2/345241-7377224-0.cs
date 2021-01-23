        public void Execute()
        {
            //should execute all the customer action in the list
            if (DuplicatesExist())
            {
                // Handle error
            }
        }
        private bool DuplicatesExist()
        {
            List<CustAction> actions = ProcessCollection(this);
            for (int x = 0; x < actions.Count; x++)
            {
                for (int y = x + 1; y < actions.Count; y++)
                {
                    if(actions[x].Equals(actions[y])
                    {
                        return true;
                    }
                }
            }
            return false;
         }
        // Recursively get all customer actions
        private List<CustAction> ProcessCollection(CustActionCollction actions)
        {
            List<CustAction> ret = new List<CustAction>();
            foreach (ICustAction action in actions._custActions)
            {
                if (action is CustActionCollction)
                {
                    ret.AddRange(ProcessCollection(action as CustActionCollction);
                }
                else
                {
                    ret.Add(action as CustAction);
                }
             }
             return ret;
         }
