    bool UserExists(string userIdToCheck, Action<bool> callback) {
      reference.Child("users").Child(userIdToCheck).GetValueAsync().ContinueWith(task=>
    {
       if(task.IsCompleted)
       {
           if(task.Result == null)
               callback(false);
           else 
               callback(true);
       )};   
    }
