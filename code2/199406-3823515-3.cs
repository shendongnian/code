    private void SomeButton_Click(...)
    {
        IBusinessObject obj = new BusinessObject(injectable form data);
        using (IPersistence store = new FilePersistence(...))
        {
            obj.Persist(store);
        }
    
        obj.DoBusinessRules();
    }
