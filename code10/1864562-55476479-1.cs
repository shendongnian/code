    bool UserExists(string userIdToCheck) {
      reference.Child("users").Child(userIdToCheck).GetValueAsync().ContinueWith(task=>
    {
       if(task.IsCompleted)
       {
           if(task.Result == null)
               ShowError("User Id is invalid");
           else 
               FriendsManager.instance.SendRequest(friendId);
       )};   
    }
