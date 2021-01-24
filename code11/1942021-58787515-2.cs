    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            HideAndShow(2.0f); // 2 second
            // Decrease Health
            handler.decreaseHealth(decreaseHealth);
        }
    }
    private void HideAndShow(float delay)
    {
        gameObject.SetActive(false);
        // Call Show after delay seconds
        Invoke(nameof(Show), delay);
    }
    private void Show ()
    {
        gameObject.SetActive(true);
    }
