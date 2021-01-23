    public interface IMyDbSet<T> where T : IEnumerable<User>
    {
       // Because T is IEnumerable<User> or one of it descendant
       // this property is similar to IEnumerable<User> Users {get;}
       T Users {get;}
    }
    
    // Now we're implementing not IMyDbSet interface itself
    // but we're IMyDbSet<IList<User>> instead.
    // Note you could use your own descendant for IEnumerable<User> here
    public class ConcreteDbSet : IMyDbSet<IList<User>>
    {
    	public IList<User> Users {get; set;}
    }
    //...
    // and now you could use ConcreteDbSet following way:
    var set = new ConcreteDbSet();
    IList<User> users = set.Users;
