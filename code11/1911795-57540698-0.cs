    public void UpdateLeaderBoard()
    {
            FirebaseDatabase.DefaultInstance.GetReference("Players").OrderByChild("score").LimitToLast(5).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("LeaderBoardManager: read database is faulted with error: " + task.Exception.ToString());
                return;
            }
    
            if (task.IsCompleted)
            {
                if (task.Result == null)
                {
                    Debug.Log("LeaderBoardManager: ReadData ==> task result is null.");
                }
    
                DataSnapshot snapshot = task.Result;
                Dictionary<string, System.Object> attributes = (Dictionary<string, System.Object>)snapshot.Value;                
    
                if (snapshot.Exists)
                {
                    int i = 0;
                    foreach (DataSnapshot childSnapshot in snapshot.Children)
                    {
                        Top5[i, 0] = childSnapshot.Key;
                        Dictionary<string, System.Object> attributes2 = (Dictionary<string, System.Object>)childSnapshot.Value;
                        Top5[i, 1] = attributes2["nick"].ToString();
                        Top5[i, 2] = attributes2["score"].ToString();
                        Top5[i, 3] = attributes2["level"].ToString();
                        Top5[i, 4] = attributes2["victory"].ToString();
                        Top5[i, 5] = attributes2["defeat"].ToString();
    
                        i++;
                    }
                }
            }
        });        
    }
