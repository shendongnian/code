    // For storing the reference
    // If possible already reference this via the Inspector 
    // by drag&drop to avoid Find entirely!
    [SerializeField] private Transform target;
    private bool rotate;
    private void Start()
    {
        if(!target) target = GameObject.Find("Globe");
    }
    public void ToggleRoutine()
    {
        rotate = !rotate;
        if(!rotate)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine (RotateContinuously());
        }
    }
    private IEnumerator RotateContinuously()
    {
        // Whut? o.O
        // No worries, this is fine in a Coroutine as long as you yield somewhere inside
        while (true)
        {
            // You should use Find only once .. if at all. You should avoid it wherever possible!
            if(!target) target = transform.Find("Globe");
            smooth = Time.deltaTime * smoothTime * convertedTime;
            target.Rotate(rotationDirection * smooth);
            // Very important for not freezing the editor completely!
            // This tells unity to "pause" the routine here
            // render the current frame and continue
            // from this point on the next frame
            yield return null;
        }
    }
