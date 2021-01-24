    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("White Ball")) 
        {
            // Disable this collider immediately to prevent redundant scoring, sound cues, etc.
            GetComponent<Collider2D>().enabled = false;
            ScoreScript.scoreValue += 1;
            StartCoroutine(ChangeColor());
        }
    }
