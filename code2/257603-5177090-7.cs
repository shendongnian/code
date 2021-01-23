    public class TodoPresenter
    {
        private Func<DataContext> dataContextFactory;
        private Func<DataContext, ITodoService> serviceFactory;
        // created with new TodoPresenter(DataContextFactory.GetNewContextForDatabase1(), 
        //                   dc => new TodoService(dc, 
        //                              new ToDoRepository(dc => new ToDoRepository(dc))));
        public TodoPresenter(Func<DataContext> dataContextFactory, 
                             Func<DataContext, ITodoService> serviceFactory)
        {
            this.dataContextFactory = dataContextFactory;
            this.serviceFactory = serviceFactory;
        }
        public void Save()
        {
            using (DataContext dataContext = this.dataContextFactory())
            {
                ITodoService service = serviceFactory(dataContext);
                // ...
                //service.Save(..);
                //dataContext.SubmitChanges();           
            }
        }
    }
