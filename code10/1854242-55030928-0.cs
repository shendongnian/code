    public float lerpSpeed = 2;
    private float t = 0;
    public void FillBar()
    {
        bar.fillAmount = Mathf.Lerp(0f, 0.7f, t);
        t += Time.deltaTime * lerpSpeed
    }
