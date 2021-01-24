    public IHttpActionResult GetData(int id) 
    {
      //now the only function of this is to wrap in an ActionResult
      List<MyData> dataList = GetDataAsList(id);
      return Ok(dataList .ToList());
    }
    
    public List<MyData> GetDataAsList(int id)
    {
      ... do your work to get the information
      List<MyData> dataList = getArrayOfRecords();
      return dataList;
    }
