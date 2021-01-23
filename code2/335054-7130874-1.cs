     void GetData(SomeArgument a, Action<SomeResult> success)
     {
          var fn = AsyncExecute<SomeResult>(cb => service.BeginGetData(a, cb, null), service.EndGetData);
          fn(success, GeneralFail);
     }
     public static void GeneralFail(Exception err)
     {
          // General reporting of fail
     }
