    [Route("api/test/{id}")]
    public test Get(int id)
    {
        using (Raw_DataEntities entities = new Raw_DataEntities())
        {
            return entities.tests.FirstOrDefault(e => e.ID == id).ToJsonWrapper();
        }
    }
