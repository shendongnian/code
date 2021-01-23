    public class User
    {
        public string name { get; set; }
        public string userID {get;set; }
    }
		
    public interface ISpecification<T>
    {
        boolean IsSatisfiedBy(T obj);
    }
    public class IdValidUserSpecification : ISpecification<User>
    {
        public boolean IsSatisfiedBy(User user)
        {
             return user.userID >= 101 || user.userID < 1;
        }
    }
    public class NameLongEnoughUserSpecification : ISpecification<User>
    {
        public boolean IsSatisfiedBy(User user)
        {
             return user.Name.Length > 10;
        }
    }
    ...	    
    public void DoSomething()
    {
    	ISpecification<User> idValid = new IdValidUserSpecification();
    	ISpecification<User> nameValid = new NameLongEnoughUserSpecification();
        User user = new User();
    	user.name = "Jaapjan";
    	user.userID = 101;
        if (nameValid.IsSatisfiedBy(user) && idValid.IsSatisfiedBy(user))
    		...;
    }
