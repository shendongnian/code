    // Recommendation: assign Text here in the inspector
    public Text textToScale;
    public float halfDuration = 0.5f;    
    public float bigScaleMultiplier = 1.5f;
    private Coroutine effectCoroutine = null;
    private Vector3 scaleStart;
    
    // call this to begin the effect
    public void StartEffect()
    {
        // ensure duplicates don't run
        if (effectCoroutine == null)
        {
            effectCoroutine = StartCoroutine(DoEffect());
        }
    }
    
    private IEnumerator DoEffect()
    {
        float elapsed = 0f;
        scaleStart = textToScale.rectTransform.localScale;
        float scaleMultiplierIncrease = bigScaleMultiplier - 1f;
    
        while (elapsed <= halfDuration * 2f)
        {
            // t = What fraction of "big" we are currently at
            float t = Mathf.InverseLerp(0f, halfDuration, Mathf.PingPong(elapsed, halfDuration));
    
            float curScaleMultiplier = 1f + scaleMultiplierIncrease * t;
    
            textToScale.rectTransform.localScale = curScaleMultiplier * scaleStart;
            yield return null;
            elapsed  += Time.deltaTime;
        }
    
        effectCoroutine = null;
    }
