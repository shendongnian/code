Queue<PoolObject> availableObjects = new Queue<PoolObject>();
class PoolObject 
{
    public Transform transform;
    public bool inUse;
    public PoolObject(Transform t) { transform = t; }
    public void Use() { inUse = true; }
    public void Dispose() { inUse = false; }
}
void CheckDisposeObject(PoolObject poolObject) 
{
    //place objects off screen
    if (poolObject.transform.position.x < (-defaultSpawnPos.x * Camera.main.aspect) / targetAspect) 
    {
        availableObjects.Enqueue(poolObject);
        poolObject.transform.gameObject.SetActive(false);
    }
}
Transform GetPooledObject()
{
    if(availableObjects.Count > 0)
        Transform poolObj = availableObjects.Dequeue();
        poolObj.gameObject.SetActive(true);
        return poolObj;
    else
        return null;
}
