public class Task {
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}
Also you should extract access layer (dbContext, dbSet, repositories etc.) into separate class library.
Both projects should use this two libraries. Each project should have own set of view classes. As example of view class is:
public class Task {
    public Guid Id { get; set; }
    public string Status { get; set; }
}
Your can map domain model (entity) to view model yourself or use something like Automapper (the second case is better). 
