        var map = new Dictionary<Type,Func<ITask>>
        {
            { typeof(TaskA), () => new TaskA(_singletonA, _singletonB) },
            { typeof(TaskB), () => new TaskB(_singletonA, _singletonB) },
            { typeof(TaskC), () => new TaskC(_singletonA, _singletonB) }
        };
         public T Resolve<T>()
         {
             return (T)_map[typeof(T)];
         }
