    /// <summary>
    /// Defines the behavior of a class following the Repository pattern for data access 
    /// with basic atomic operation control.
    /// </summary>
    /// <typeparam name="TRest">An interface derived from IDomainObject that describes domain objects 
    /// that can be retrieved or saved by this Repository.</typeparam>
    public interface IRepository<TRest> : IDisposable where TRest : IDomainObject
    {
        /// <summary>
        /// Begins a new unit of work to be performed atomically by the Repository.
        /// </summary>
        /// <returns>A token class representing the unit of work.</returns>
        IUnitOfWork BeginUnitOfWork();
        /// <summary>
        /// Commits all work performed under the specified unit of work.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        void CommitUnitOfWork(IUnitOfWork unitOfWork);
        /// <summary>
        /// Rolls back the specified unit of work.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        void RollBackUnitOfWork(IUnitOfWork unitOfWork);
        /// <summary>
        /// Saves the specified domain object to the data source controlled by the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        void Save<T>(T domainObject, IUnitOfWork unitOfWork) where T : class, TRest;
        /// <summary>
        /// Begins a Linq query for a specific object type, to be performed against the Repository's data source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>An IQueryable representing the query to be performed.</returns>
        IQueryable<T> QueryFor<T>(IUnitOfWork unitOfWork) where T : class, TRest;
        /// <summary>
        /// Performs the specified Action using a new unit of work, with commits and rollbacks as necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The Action to perform. The lambda or named method must accept an IUnitOfWork as a parameter.</param>
        /// <param name="commit">if set to <c>true</c>, commit the unit of work.</param>
        void PerformInNewUnitOfWork<T>(Action<IUnitOfWork> func, bool commit = false);
        /// <summary>
        /// Performs the specified Func using a new unit of work, with commits and rollbacks as necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The function to evaluate. The lambda or named method must accept an IUnitOfWork as a parameter.</param>
        /// <returns>A single object of the generic type, returned by the function.</returns>
        /// <param name="commit">if set to <c>true</c>, commit the unit of work.</param>
        T PerformInNewUnitOfWork<T>(Func<IUnitOfWork, T> func, bool commit = false) where T : class, TRest;
        /// <summary>
        /// Performs the specified Func using a new unit of work, with commits and rollbacks as necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The Function to evaluate. The lambda or named method must accept an IUnitOfWork as a parameter.</param>
        /// <returns>An enumerable set of objects of the generic type, returned by the function.</returns>
        /// <param name="commit">if set to <c>true</c>, commit the unit of work.</param>
        IEnumerable<T> PerformInNewUnitOfWork<T>(Func<IUnitOfWork, IEnumerable<T>> func, bool commit = false) where T : class, TRest;
        /// <summary>
        /// Attaches the specified domain object to the current Unit of Work, allowing operations to be performed on it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        void Attach<T>(T domainObject, IUnitOfWork unitOfWork) where T : class, TRest;
        /// <summary>
        /// Detaches the specified domain object to the current Unit of Work.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        void Detach<T>(T domainObject, IUnitOfWork unitOfWork) where T : class, TRest;
        /// <summary>
        /// Refreshes the specified collection of persistent elements with the most recent persisted data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements">The list of elements to refresh.</param>
        /// <param name="unitOfWork">The Unit of Work under which to perform the operation.</param>
        void Refresh<T>(IList<T> elements, IUnitOfWork unitOfWork) where T : class, TRest;
        /// <summary>
        /// Deletes the specified domain object from the data store. 
        /// Usually performs a physical delete; logical deletes are most often done through updates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object to delete.</param>
        /// <param name="unitOfWork">The unit of work under which to perform the operation.</param>
        void Delete<T>(T domainObject, IUnitOfWork unitOfWork) where T : class, TRest;
    }
