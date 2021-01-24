    [Route("api/test/{id}")]
    public test Get(int id)
    {
        using (Raw_DataEntities entities = new Raw_DataEntities())
        {
            var entity = entities.tests.FirstOrDefault(e => e.ID == id);
        }
        var root = new RootObject();
        // Filling the object
        root.ID = entity.Id;
        // etc. ...
        return root;
    }
