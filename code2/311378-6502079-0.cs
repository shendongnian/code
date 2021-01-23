    private List<int> deletedRecords
    {
        get
        {
            var result = ViewState["deletedRecords"] as List<int>;
    
            if ( result == null )
            {
                result = new List<int>();
                ViewState["deletedRecords"] = result;
            }
    
            return result;
        }
    }
