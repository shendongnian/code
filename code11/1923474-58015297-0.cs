    private bool requestDone;
    private DataSnapshot dataSnapshot;
    private int index;
    private void RetrieveFromDatabase(int index)
    {
        Debug.Log($"{index} started...");
        requestDone = false;
        StartCoroutine(WaitForResponce());
        FirebaseDatabase.DefaultInstance.GetReference("/Teams/" + TeamsSelection.teamSelected + "/").Child(index.ToString()).Child("userPosition").GetValueAsync()
           .ContinueWith(task => 
           {
               if (task.IsFaulted)
               {
                   //handle error
               }
               else if(task.IsCompleted)
               {
                   DataSnapshot snapshot = task.Result;
                   this.index = index;
                   thos.dataSnapshot = snapshot;
               }
               requestDone = true;
           });
    }
    private IEnumerator WaitForResponce()
    {
        while (!requestDone) yield return null;
        if (dataSnapshot == null || int.Parse(dataSnapshot.Value.ToString()) < 10)
        {
            Debug.Log("Trying again to retrieve " + index);
            RetrieveFromDatabase(index);
        }
        else
        {
            int userPos = int.Parse(dataSnapshot.Value.ToString());
            Debug.Log("retrieved userPos " + userPos);
            StartCoroutine(FetchWithUWR(userPos, index));
            //FetchWithResourceLoad(userPos, index);
        }
    }
