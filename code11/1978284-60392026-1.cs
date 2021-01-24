csharp
public interface IMapped<T>
{
   void LoadFrom(T otherType);
}
then your classes definitions would look like:
csharp
public class DeskPro : IRequest, IMapped<Request>
{
    public Guid RequestUId { get; set; }
    public Guid TicketId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime DateCreated { get; set; }
    public List<Task> Tasks { get; set; }
    public TicketSystemTypeEnum TicketSystemType { get; set; }
    public StatusEnum TicketStatus { get; set; }
    public void LoadFrom(Request r)
    {
          //MAP FROM REQUEST
    }
}
public class ServiceNow : IRequest, IMapped<Request>
{
    public Guid RequestUId { get; set; }
    public Guid TicketNumber { get; set; }
    public Guid EmployeeNumber { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<Task> Tasks { get; set; }
    public TicketSystemTypeEnum TicketSystemType { get; set; }
    public StatusEnum TicketPosition { get; set; }
    public void LoadFrom(Request r)
    {
          //MAP FROM REQUEST
    }
}
If you need to reuse your mapper class you can make your interface:
public interface IHasMapper<TMapper>
{
    TMapper GetMapper();
}
