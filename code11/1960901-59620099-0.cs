    public class Order {
       public int? Id { get; protected set; }
       public IClient Client { get; set; }
    
       public void Save() {
          RequestBLL bll = new RequestBLL();
          bll.Save(this);
       }
    
       public static Order GetBy_Id(int id) {
          RequestBLL bll = new RequestBLL();
          return bll.Get<Order>(id);
       }
    }
    
    public interface IClient {
       public int? Id { get; }
       public string Name { get; }
    
       public void Save();
    }
    
    public class Client : IClient {
       public int? Id { get; protected set; }
       public string Name { get; set; }
    
       public void Save() {
          RequestBLL bll = new RequestBLL();
          bll.Save(this);
       }
    
       public static Client GetBy_Id(int id) {
          RequestBLL bll = new RequestBLL();
          return bll.Get<Client>(id);
       }
    }
