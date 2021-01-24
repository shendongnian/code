    public void CreateUser()
    {
        var userName = inputUserName.text;
        var email = inputEmail.text;
        StartCoroutine(CreateUserRequest(userName, email));
    }
    private IEnumerator CreateUserRequest(string userName, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("emailPost", email);
        using (UnityWebRequest www = UnityWebRequest.Post(CreateUserURL, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
