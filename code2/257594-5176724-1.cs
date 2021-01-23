    public class TodoService :IDisposable
    {
       DataContext dataContext;
       IRepository<Todo> _todoRepository;
       public TodoService()
       {
           dataContext = DataContextFactory.GetNewContextForDatabase1();
           _todoRepository = new Repository<Todo>(dataContext);
       }
       public void Dispose()
       {
           dataContext.Dispose();
       }
       void Save(Todo item)
       {
           _todoRepository.Save(item);
       }
       void SubmitChanges()
       {
           _todoRepository.SubmitChanges();
       }
    }
