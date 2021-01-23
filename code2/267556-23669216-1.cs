            var p = Expression.Parameter(typeof(string), "text");
            var callExp =
                Expression.Call(
                  typeof(System.Diagnostics.Debug).GetRuntimeMethod(
                       "WriteLine", new [] { typeof(string) }),
                  p);
            Action<string> compiledAction = Expression.Lambda<Action<string>>(
                                             callExp, p)
                                             .Compile();
