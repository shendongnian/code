    Collider2D myCollider;
 
    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }
    private void OnEnable() 
    {
        myCollider.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("White Ball")) 
        {
            // Disable this collider immediately to prevent redundant scoring, sound cues, etc.
            myCollider.enabled = false;
            ScoreScript.scoreValue += 1;
            StartCoroutine(ChangeColor());
        }
    }
