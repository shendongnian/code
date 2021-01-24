    static void Main(string[] args) {
        var res1 = ExecuteAsync<double>(Func1, 30, "1.1.1.1", "user", "looser");
    }
    public static double Func1(object[] args) {
        string ip = (string)args[0], username = (string)args[1], password = (string)args[2];
        // do some work 
        return 0.0;
    }
    public static T? ExecuteAsync<T>(Func<object[], T> func, int timeout /* sec */, params object[] args) where T : struct {
        var task = Task.Factory.StartNew(() => func(args));
        if (task.Wait(timeout * 1000))
            return task.Result;
        return null;
    }
