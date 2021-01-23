        interface IRepository<T>
        {
        }
    
        interface IRep<T> : IRepository<IRepoItem> where T : IRepoItem
        {
        }
    
        interface IBookRepository : IRep<Book>
        {
        }
    
        class BookRepository : IBookRepository
        {
        }
