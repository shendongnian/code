public GameObject[] Bricks;
void SpawnBricks(int numCubes = 20, float startY = 3, float delta = 0.6f, float AngleDis = 3f)
{
    GameObject Brick;
    int Rand = Random.Range(0, Bricks.Length);
    for (int i = 0; i < numCubes; ++i)
    {
        Brick = Instantiate(Bricks[Rand], new Vector3(0, startY - (float)i * delta, 0), Quaternion.identity);
        Brick.transform.parent = gameObject.transform;
    }
    // Brick now holds the last object returned from Instantiate in the loop
}
