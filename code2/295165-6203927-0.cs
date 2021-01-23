        /// <summary>
        /// The Action callback for the LoadEntityQuery handler. This callback is used to respond to the 
        /// LoadEntityQuery when all Load calls are complete. See the Handle method 
        /// </summary>
        private Action<LoadEntityQueryResult> _reply = null;
        /// <summary>
        /// Accumulator used to determine when the last entity has been loaded
        /// </summary>
        private int EntityCount { get; set; }
        /// <summary>
        /// Collective error container for Errors from the LoadOperation. This is value is returned via
        /// the _reply callback to the calling code.
        /// </summary>
        private List<Exception> Errors = null;
        public void Handle(LoadEntityQuery loadQuery, Action<LoadEntityQueryResult> reply)
        {
            _reply = reply;
            Errors = new List<Exception>();
            EntityCount = loadQuery.Entities.Count();
            MethodInfo _loadOpMethod = this.GetType().GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Instance);
            int _entityCount = loadQuery.Entities.Count();
            foreach (var entry in loadQuery.Entities)
            {
                Type entityType = entry.Key;
                Type _contextType = EmployeeJobsContext.Instance.GetType();
                MethodInfo _methodInfo = (from x in _contextType.GetMethods()
                                          where x.ReturnType.BaseType == typeof(EntityQuery)
                                          from y in x.ReturnType.GetGenericArguments()
                                          where y == entityType
                                          select x).FirstOrDefault();
                if (_methodInfo != null)
                {
                    var query = _methodInfo.Invoke(EmployeeJobsContext.Instance, null);
                    MethodInfo _typedLoadOpMethod = _loadOpMethod.MakeGenericMethod(new Type[] { entityType });
                    _typedLoadOpMethod.Invoke(this, new[] { query, entry.Value});
                }
            }
        }
        private void Load<T>(EntityQuery<T> query, Expression<Func<T, bool>> where) where T: Entity
        {
            if (where != null)
                query = query.Where(where);
            EmployeeJobsContext.Instance.Load(query, (loadOp) =>
                {
                    EntityCount--;
                    if (loadOp.HasError)
                    {
                        Errors.Add(loadOp.Error);
                        loadOp.MarkErrorAsHandled();
                    }
                    if (EntityCount == 0)
                        _reply(new LoadEntityQueryResult { ErrorList = Errors });
                }, null);
        }
