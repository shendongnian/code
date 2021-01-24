public class TileBump : MonoBehaviour
{
    public Transform m_GridParent;
    public GameObject m_TileMap_Prefab;
    public AnimatedTile m_tilePrefabAnimated;
    public Tile m_tilePrefabStatic;
    private Tilemap map;
    void Start()
    {
        StartCoroutine(EStart());
    }
    public IEnumerator EStart()
    {
        GameObject t = Instantiate(m_TileMap_Prefab, m_GridParent);
        map = t.GetComponent<Tilemap>();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                map.SetTile(new Vector3Int(i, j, 0), m_tilePrefabAnimated);
                StartCoroutine(Operation(new Vector3Int(i, j, 0)));
                yield return new WaitForSeconds(0.3f);
            }
        }
        
    }
    public IEnumerator Operation(Vector3Int x)
    {
        yield return new WaitForSeconds(m_tilePrefabAnimated.m_AnimatedSprites.Length / m_tilePrefabAnimated.m_AnimationSpeed);
        map.SetTile(x, m_tilePrefabStatic);
    }
}
BUT. What i understood here is that tiles are not for that. Every tile in TileMap refer to ScriptableObject, so every animation will be same in every frame.
However if someone need this kind of effect, its one way to do it.
