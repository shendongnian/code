    using System.Collections;
...
    private IEnumerator EnemyGenerator()
    {
        while (true)
        {
            Vector3 randPosition = transform.position + (Vector3.up * Random.value); //Example of randomizing
            Instantiate (enemyPrefeb, randPosition, Quaternion.identity);
            yield return new WaitForSeconds(generatorTimer);
        }
    }
    public void StartGenerator()
    {
        StartCoroutine(EnemyGenerator());
    }
    public void StopGenerator()
    {
        StopAllCoroutines();
    }
