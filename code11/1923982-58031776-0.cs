    interface IHasId
    {
        int Id { get; }
    }
    private T AddRecord<T>(List<T> listofRecords) where T: IHasId
    {
        foreach (var rec in listofRecords)
        {
           var theId = rec.Id;
        }
        ...
    }
