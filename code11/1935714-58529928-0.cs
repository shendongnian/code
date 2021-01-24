    public CharacterController CharController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FloorTag"))
        {
            CharController.enabled = false;
            transform.position = StartingPlatformCoords;
            CharController.enabled = true;
            Lives -= 1;
            SetLivesText();
            Debug.Log(transform.position);
        }
        if (other.gameObject.CompareTag("CellTag"))
        {
            Points += 1;
            SetPointsText();
        }
    }
