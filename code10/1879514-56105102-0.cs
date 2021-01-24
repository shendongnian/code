    void SpawnBricks(int numCubes = 10, float startY = 3, float delta = 1)
    {
        int Rand = Random.Range(0, Bricks.Length);
        for (int i = 0; i < numCubes; ++i)
        {
            var Brick = Instantiate(Bricks[Rand], new Vector3(0, startY - (float)i * delta, 0), Quaternion.identity);
            Brick.transform.parent = gameObject.transform;
        }
    }
