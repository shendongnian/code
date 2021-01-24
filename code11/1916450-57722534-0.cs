 c#
public class Request
{
    public int RequestId {gets;set;}
    public DateTime CreationDate {get;set;}
    public string CreatedBy {gets;set;}
    public bool Active {Get;set;}
}
public class RequestChildA
{
    public string RequestChildAProp1 {get;set;}
    public string RequestChildAProp2 {get;set;}
    ...
    public virtual Request Request {get; set;}
}
public class RequestChildB : Request
{
    public string RequestChildBProp1 {get;set;}
    public string RequestChildBProp1 {get;set;}
    ...
    public virtual Request Request {get; set;}
}
