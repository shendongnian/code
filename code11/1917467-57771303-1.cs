    if (transform.Find("ExclamationMark"))
    {
        var exMark = transform.Find("ExclamationMark").gameObject.GetComponent<ExclamationMarkSpawn>();        
        exMark.SpawnExclamationMark(transform.position); //Add transform.position here
    }
    public void SpawnExclamationMark(Vector3 EnemyPos)
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().Shake(0.2f, 0.2f, 0.2f));
        Instantiate(exclamationMark, EnemyPos, Quaternion.identity);
        if (exclamationMarkAudio)
            Instantiate(exclamationMarkAudio, EnemyPos, Quaternion.identity);
        StartCoroutine(DestroyExclamationMark());
    }
