    private static object _lockObj = new object();
    public static bool HasLock(int userId)
    {
       lock(_lockObj)    
       {
         var i = userId;
         var hasLock = UserLocks.TryPeek(out i);
         if (hasLock)
             return true;
         UserLocks.Add(userId);
         return false;
       }
    }
