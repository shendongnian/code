    IEnumerator GetUserData(){
        var getTask = reference.Child("users").Child(PlayerPrefs.GetString("userUID")).GetValueAsync();
        yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);
        if (getTask.IsCompleted)
        {
            Dictionary<string, object> results = (Dictionary<string, object>)task.Result.Value;
            userName= (string)results["userName"];
            Debug.Log(userName);
            userNameText.text = userName;
        }
    }
