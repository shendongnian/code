    class Bar {
    private DataAccessService service
    
    public void Foo()
    {
        // some data validation logic here
    
        if (some_criteria_is_true)
        {
            // Call to a method which uses sql queries to update some records
            service.updateBarRecords();
        }
        else
        {
            // Call to a method which uses sql queries to delete some records
            service.deleteBarRecords();
        }
    }
    
    }
