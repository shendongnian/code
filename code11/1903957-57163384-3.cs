    private void Start()
    {
        float sampleRate = MainFlow.Length / 60f;
        secondsPerSample = 1 / sampleRate;
        StartCoroutine(Process());
    }
    
    private IEnumerator Process()
    {
        for (int i = 0; i < MainFlow.Length; i++)
        {
            float f = (float) MainFlow[i]; // value of current volume
            float k = f + 2.5f; // adding initial volume
            transform.localScale = new Vector3(k, k, k); i++;
            yield return new WaitForSeconds(secondsPerSample);
        }
        
        yield return Process();
    }
