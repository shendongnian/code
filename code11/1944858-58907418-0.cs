c#
        public Func<T, int> Sum { get; private set; }
        public void Compile()
        {
            var parm = Expression.Parameter(typeof(T), "parm");
            Expression sum = null;
            foreach(var p in typeof(T).GetFields())
            {
                var member = Expression.MakeMemberAccess(parm, p);
                sum = sum == null ? (Expression)member : Expression.Add(sum, member);
            }
            Sum = Expression.Lambda<Func<T, int>>(sum, parm).Compile();
        }
Or perhaps just a method that turns the struct into some other kind of enumerable that's easier to work with.
