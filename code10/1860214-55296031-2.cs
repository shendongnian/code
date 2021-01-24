    private Coroutine coroutine;
    private void OnTriggerEnter(Collider other)
    {
        if(coroutine == null && other.CompareTag("Player"))
        {
            coroutine = StartCoroutine(YourCoroutine());
        }
    }
