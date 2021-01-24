 chsarp
...
public string previousGameObjectsInfo = "";   // to store the previous state
public string gameObjectsInfo = "";
...
private void Update()
{
    if(gameObjectsInfo != "" && gameObjectsInfo != previousGameObjectsInfo)
    {
        Search();   // or anything else
    }
    previousGameObjectsInfo = gameObjectsInfo;
}
