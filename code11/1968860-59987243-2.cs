    private IEnumerator Start()
    {
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(-1.88f, 2.1f), Random.Range(-7.81f, -3.1f));
            Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
