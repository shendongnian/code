    //your ApplicationModel
    public class BaseModel
    {
      public Guid GuidId{get;set;}
      public int Id{get;set;}
    }
    
    public BaseModel Map(Base dto)
    {
      var model=new BaseModel();
      Guid.TryParse(dto.Id,out model.GuidId);
      int.TryParse(dto.Id, out model.Id);
    }
