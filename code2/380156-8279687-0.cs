        public static TViewModel GetSingle<T, TViewModel, TRepository>(Expression<Func<T, bool>> whereCondition, TRepository repository)
            where T : class, Entity
            where TViewModel : class, IViewModel<T>, new()
            where TRepository : IRepository<T>
        {
            T member = repository.GetSingle(whereCondition);
            if (member != null)
            {
                return new TViewModel().MapFrom(member);
                // or however you map from member to its view model 
            }
            return null;
        }
