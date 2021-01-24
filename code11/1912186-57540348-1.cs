    private Coroutine reScaleCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
        {
         reScaleCoroutine = StartCoroutine(ReScale(new Vector3(.5f, .5f), new Vector3(0.1f, 0.1f), collision));
        }
    
    private void StopCoroutineMethod()
        {
         StopCoroutine(reScaleCoroutine);
        }
    
