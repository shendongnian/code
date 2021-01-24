    IEnumerator Example(string url, DateTime realToday, DateTime realFistDate)
    {
        LoadingAnimator.SetBool("ActiveLoad", true);
        yield return new WaitForSeconds(1);
        var www = new WWW(url);
        Debug.Log("Requesting " + url);
        while (realToday != realFistDate)
        {
            images.Add(realFistDate.ToString("dd.M.yyyy HH"), returnSprite(realFistDate, TypeString));
            imagesTime.Add(realFistDate.ToString("dd.M.yyyy HH"));
            realFistDate = realFistDate.AddHours(1);
        }
        yield return www;
        UnityEngine.Debug.Log("Rquest completed");
        yield return new WaitForSeconds(1);
        UnityEngine.Debug.Log("Proceeding");
        LoadingAnimator.SetBool("ActiveLoad", false);
        ShowData();
    }
