c#
public Gameobject myNewGameObjectPrefab; //drag your prefab here in the inspector
void DestroyAndCreate(Gameobject myGameObject)
{
    GameObject newObj = Instantiate(myNewGameObjectPrefab, myGameobject.transform.position);
    Destroy(myGameobject);
}
