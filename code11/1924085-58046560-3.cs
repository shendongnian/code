    reference.Child("users").GetValueAsync().ContinueWith(task => 
    {
        if (task.IsFaulted) 
        {
            // Handle the error...
        }
        else if (task.IsCompleted) 
        {
            DataSnapshot snapshot = task.Result;
            // Do something with snapshot...
            
            // Again either using a JSON
            var user = JsonUtility.FromJson<User>(snapshot.Child(userId).GetRawJsonValue());
            var username = user.username;
            // OR using the path to get a single value
            var username = (string)snapshot.Child(userId).Child("username").Value();
            // Now do something with the received data
        }
    });
