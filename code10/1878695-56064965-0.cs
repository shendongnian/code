    public class MemberDetail : IMemberDetail
    {     
      public String Email { get; set; }
      public IDataFields DataFields { get; set; }
      public MemberDetail(IDataFields dataFields)
      {
        DataFields = dataFields;
      }
    }
