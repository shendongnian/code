    public void ReadDatabase()
    {
        string uid;
        if (usermanager != null && usermanager.user != null)
        {
            uid = usermanager.user.UserId;
            Debug.Log("DataManager: Set User ID from UserManager for User: " + uid);
        }
        else
        {
            Debug.LogError("DataManager: Set User not set.");
            return;
        }
        FirebaseDatabase.DefaultInstance.GetReference("Players").Child(uid).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("DataManager: read database is faulted with error: " + task.Exception.ToString());
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log("DataManager: Read scores");
                Dictionary<string, System.Object> attributes = (Dictionary<string, System.Object>)snapshot.Value;
                if (snapshot.Exists)
                {
                    Debug.Log("DataManager: UID ==> " + attributes["uid"].ToString());
                    Debug.Log("DataManager: Score ==> " + attributes["score"].ToString());
                    Debug.Log("DataManager: Level ==> " + attributes["level"].ToString());
                    Debug.Log("DataManager: Kill ==> " + attributes["kill"].ToString());
                    Debug.Log("DataManager: Death ==> " + attributes["death"].ToString());
                    Debug.Log("DataManager: XP ==> " + attributes["xp"].ToString());
                    Debug.Log("DataManager: Live ==> " + attributes["live"].ToString());
                }
                else
                {
                    Debug.LogError("DataManager: Database for the user not available.");
                }
                
            }
        });
    }
