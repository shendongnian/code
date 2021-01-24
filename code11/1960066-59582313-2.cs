    public class MyClass : IGuidIdBusinessService<object>
    {
      #region Implementation of IBusinessService<object>
     
      ...
      // Either throw NotSupportedException or implement conversion
      public async Task<object> GetById(int id)
      {
        Guid guid = ConvertIntToGuid(id);
        return GetByGuid(guid);
      }
      #endregion
      #region Implementation of IGuidIdBusinessService<object>
      public async Task<object> GetByGuid(Guid id) => throw new NotImplementedException();
      #endregion
    }
