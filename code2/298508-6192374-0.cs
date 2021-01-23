    public interface ICustomer {}
    
    public abstract class SapEntity {}
    public abstract class NHibernateEntity {}    
    public class SapCustomer : SapEntity, ICustomer {}
    public class NHibernateCustomer : NHibernateEntity, ICustomer {}
    public class CustomerProcessor
    {
       public ICustomer GetCustomer(int customerID)
       {
          // business logic here
       }
    }
    
    
