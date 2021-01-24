    //your ApplicationModel
    public class BaseModel
    {
      public Guid GuidId{get;set;}
      public int Id{get;set;}
      public IdType{get;set;}
      
      public enum IdType
      {
         Guid,
         Int
      }
    }
    
    public BaseModel Map(Base dto)
    {
      var model=new BaseModel{Type= dto.Type};
      var guidResult = Guid.TryParse(dto.Id,out model.GuidId);
      if(!guidResult) int.TryParse(dto.Id, out model.Id);
      model.IdType = guidResult?IdType.Guid:IdType.Int;
      return model
    }
