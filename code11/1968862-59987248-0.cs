public class Spawnnoif : MonoBehaviour
{
    public GameObject[] prefabs;
    public int x;
    public GameObject paleta;
    public float delta;
    void Start()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-1.88f, 2.1f), 1, UnityEngine.Random.Range(-7.81f, -3.1f));
        x = UnityEngine.Random.Range(0, prefabs.Length - 1);
        Instantiate(prefabs[x], position, Quaternion.identity);
    }
    ...
}
