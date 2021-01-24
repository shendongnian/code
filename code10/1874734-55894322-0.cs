csharp
// This will be the reference to the PREFAB
public GameObject big_rock;
// This will be the referenced to the new spawned gameobject
private GameObject spawned_big_rock;
private void SpawnRock()
{
    GameObject gameobjectThatWeJustSpawned = Instantiate(big_rock);
    // We set the reference to the one that was spawned
    spawned_big_rock = Instantiate(big_rock);
}
public void DestroyRock()
{
    // We destroy the one that was spawned
    Destroy(spawned_big_rock);
}
