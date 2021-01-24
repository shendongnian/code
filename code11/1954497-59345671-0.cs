private class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Spawn() => Instantiate(prefab);
}
So that your throw code should spawn a ball and if you want destroy an older one.
