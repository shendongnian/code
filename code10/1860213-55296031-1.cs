    private Coroutine coroutine;
    private void OnTriggerEnter(Collider other)
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(YourCoroutine());
        }
    }
