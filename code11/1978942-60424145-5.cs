    public class Data {
        public int Id {get;set;}
        public int ParentId {get;set;}
        public string Title {get;set;}
    }
    List<Data> customList = await db.MyDbTable
    .Select(x => new Data { Id = x.Id, ParentId = x.ParentId, Title = x.Title })
    .ToListAsync();
    private void MyMethod(List<Data> inputList)
    {
        // process the input list
        return;
    }
