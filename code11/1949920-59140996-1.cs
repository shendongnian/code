    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player" && !isCollected) {
            isCollected = true;
            theLevelManager.AddDiamond ();
            DiamondUI.SetActive (true);
            gameObject.SetActive (false);
        }
    }
