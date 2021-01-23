        public static Func<T, TResult> AsCached<T, TResult>(this Func<T, TResult> function)
        {
            var cachedResults = new Dictionary<T, TResult>();
            return (argument) =>
            {
                TResult result;
                lock (cachedResults)
                {
                    if (!cachedResults.TryGetValue(argument, out result))
                    {
                        result = function(argument);
                        cachedResults.Add(argument, result);
                    }
                }
                return result;
            };
        }
        public static Func<T1, T2, TResult> AsCached<T1, T2, TResult>(this Func<T1, T2, TResult> function)
        {
            var cachedResults = new Dictionary<Tuple<T1, T2>, TResult>();
            return (value1, value2) =>
            {
                TResult result;
                var paramsTuple = new Tuple<T1, T2>(value1, value2);
                lock(cachedResults)
                {
                    if (!cachedResults.TryGetValue(paramsTuple, out result))
                    {
                        result = function(value1, value2);
                        cachedResults.Add(paramsTuple, result);
                    }
                }
                return result;
            };
        }
        public static Func<T1, T2, T3, TResult> AsCached<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function)
        {
            var cachedResults = new Dictionary<Tuple<T1, T2, T3>, TResult>();
            return (value1, value2, value3) =>
            {
                TResult result;
                var paramsTuple = new Tuple<T1, T2, T3>(value1, value2, value3);
                lock(cachedResults)
                {
                    if (!cachedResults.TryGetValue(paramsTuple, out result))
                    {
                        result = function(value1, value2, value3);
                        cachedResults.Add(paramsTuple, result);
                    }
                }
                return result;
            };
        }
