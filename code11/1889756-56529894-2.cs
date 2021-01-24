    public AudioSource direction;
    
    private bool running = false;
    public IEnumerator audioPlayCoroutine;
    
    IEnumerator AudioPlay()
    {
        while (true)
        {
            direction.Play();
    
            yield return new WaitForSeconds(2);
        }
    
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
    
            if (running == false)
            {
                audioPlayCoroutine = AudioPlay();
    
                StartCoroutine(audioPlayCoroutine);
    
                Debug.Log("Started");
    
                running = true;
            }
    
            else if (running == true)
            {
                Debug.Log("Void");
            }
    
        }           
    
    }
