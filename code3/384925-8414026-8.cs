    public interface IWithUserId
    {
        public int UserId { get; set; }
    }
    public partial class ClassA : IWithUserId 
    {
       
    }
    public partial class ClassB  : IWithUserId
    {
      
    }
