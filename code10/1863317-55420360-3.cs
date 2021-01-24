    using(var www = UnityWebRequest.Get(URL)
    {
        www.SendWebRequest();
        while(!www.isDone){
        ...
    }
