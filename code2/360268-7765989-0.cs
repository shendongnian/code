    public interface IChild 
    { 
    DateTime Date { get; } 
    Parent Parent { get; set; } 
    IChild Create(Session session);
    } 
 
    public class Boy : IChild 
    {
    public virtual Parent Parent { get; set; } 
    public virtual DateTime GraduationDate { get; set; } 
    public virtual DateTime Date { get { return GraduationDate; } set { } } 
    public virtual IChild Create(Session session) { return session.Query<Boy>().Where(x => x.Date == entity.Date).SingleOrDefault(); }
    } 
 
    public class Girl : IChild 
    { 
    public virtual Parent Parent { get; set; } 
    public virtual DateTime WeddingDate { get; set; } 
    public virtual DateTime Date { get { return WeddingDate; } set { } } 
    public virtual IChild Create(Session session) { return session.Query<Girl>().Where(x => x.Date == entity.Date).SingleOrDefault(); }
    } 
 
    public bool Create(IChild entity) 
    {             
        //Is there an existing child record for the key details 
        return entity.Create(Session).Parent != null;
    } 
