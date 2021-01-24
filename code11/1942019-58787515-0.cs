    public void HideAndShow()
    {
        gameObject.SetActive(false);
        // Call Show after 3 seconds
        Invoke(nameof(Show), 3f);
    }
    void Show ()
    {
        gameObject.SetActive(true);
    }
