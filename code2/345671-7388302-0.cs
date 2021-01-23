    public interface IToolRepository
    {
       void Add(Tool something);
       IQueryable<Tool> Query { get; }
       void Delete(Tool something);
    }
