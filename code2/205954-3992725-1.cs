    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string DoStuff(User user);
    }
    public class Service1 : IService1
    {
        public string DoStuff(User user)
        {
            string result = string.Empty;
            foreach (Guid leadId in user.AssociatedLeadIds) 
            {
                // This is going to console on client,
                // just making sure we can read the data sent to us
                result += leadId.ToString() + "\n";
            }
            return result;
        }
    }
    // partial entity model class
    public partial class User
    {
        // This is not persisted to our DB with the user model
        [DataMember]
        public ICollection<Guid> AssociatedLeadIds { get; set; }
    }
