    private GameObject playerPrefab;
    private GameObject player;
    public void KilledWaitTime()
    {
        SetLivesText();
        player = Instantiate(playerPrefab); //respawns player after killed
        playerCollider = player.GetComponent<Collider>();
        shield.SetActive(true);
        playerCollider.enabled = false; //disables collider while shield up.
        Debug.Log("collider = " + playerCollider.name);
        Debug.Log("player = " + player.name);
        Invoke("RemoveShields", 3);
    }
