    public class GenericRepository<TDataContext> : IGenericRepository where TDataContext: IDataContext,new()
        {
            
            public TDataContext dc = new TDataContext();
    
            // bla bla bla
        }
    
        public class CategoryRepository:GenericRepository<MyDataContext>
        {
            // bla bla bla
            public void SaveSomething()
            {
                dc.Save();
            }
        }
