    public static class TaskMonad
        {
            public static Task<T> ToTask<T>(this T t)
            {
                return new Task<T>(() => t);
            }
    
            public static Task<U> SelectMany<T, U>(this Task<T> task, Func<T, Task<U>> f)
            {
                return new Task<U>(() =>
                {
                    task.Start();
                    var t = task.Result;
                    var ut = f(t);
                    ut.Start();
                    return ut.Result;
                });
            }
    
            public static Task<V> SelectMany<T, U, V>(this Task<T> task, Func<T, Task<U>> f, Func<T, U, V> c)
            {
                return new Task<V>(() =>
                {
                    task.Start();
                    var t = task.Result;
                    var ut = f(t);
                    ut.Start();
                    var utr = ut.Result;
                    return c(t, utr);
                });            
            }
        }
