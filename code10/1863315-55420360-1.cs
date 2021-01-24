    public void UpdateProgress(UnityWebRequest www)
    {
        isDone = www.isDone;
        progress = www.downloadProgress;
    }
