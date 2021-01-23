    public List<Person> Get(int? parentPersonID = null) {
        var persons = Repository().GetAll(parentPersonID == null ? 
              c => !c.ParentID.HasValue :                
              c => c.ParentID == parentPersonID);
        ... 
    }
