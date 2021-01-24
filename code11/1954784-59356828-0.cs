    private void Awake()
    {
        StartCoroutine(IncrementCoroutine(5, 1));
    }
    private IEnumerator IncrementCoroutine(int maxCounter, float timeBetweenIncrement)
    {
        WaitForEndOfFrame endofFrame = new WaitForEndOfFrame();
        int counter = 0;
        float timer = 0;
        
        while (counter < maxCounter)
        {
            print($"Counter : {counter}");
            while (timer < timeBetweenIncrement)
            {
                timer += Time.deltaTime;
                yield return endofFrame;
            }
            timer = 0;
            counter++;
        }
    }
