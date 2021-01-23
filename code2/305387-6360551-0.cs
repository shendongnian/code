    public void Process()
    {
        try {
            Order o = new Order();
            // Do stuff
        } finally { 
            o.Complete(GetTransactionId());
        }
    }
