public class RequestChildB
{
    public virtual Request Request {get;set;}
    public string RequestChildBProp1 {get;set;}
    public string RequestChildBProp1 {get;set;}
}
and insert data like this:
db.RequestChildB.Add(new RequestChildB
{
    Request = db.Request.Find(1),
    //...other properties
});
db.SaveChanges();
