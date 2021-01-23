    public interface IRepository<T> 
    {
       T CreateObject(IConstructionParameters parameters);     
    } 
    public sealed class OrderConstructionParameters : IConstructionParameters
    {
        public Customer Customer
        { 
           get; 
           private set; 
        }
    }
