    public static void ExecuteTask<T>(this Task<T> BackgroudJob, Action<T> UIJob, Action<Exception> OnError = null) where T : struct
        {
            Action work = async () =>
             {
                 T? ret = null;
                 try
                 {
                     ret = await BackgroudJob;
                     //throw new Exception("My exception !!!");
                 }
                 catch (Exception ex)
                 {
                     try
                     {
                         if (OnError != null)
                         {
                             OnError(ex);
                         }
                         System.Diagnostics.Debug.WriteLine(ex);
                     }
                     catch { }//eat exception
                 }
                 if (ret.HasValue)
                 {
                     UIJob(ret.Value);
                 }
             };
            work();
        }
