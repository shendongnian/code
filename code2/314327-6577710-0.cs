    interface EntityGateway<TEntity> {
        TEntity Load(String id);
        void Save(TEntity entity);
    }
    public class XEntityGateway implements EntityGateway<XEntity> {
        XEntity Load(String id) { ... implementation details } 
        void Save(XEntity entity) { ... implementation details } 
    }
    
    XEntityGateway gw = new XEntityGateway();
    XEntity entity = gw.Load("SOMEID");
    // modify entity
    gw.Save(entity);
