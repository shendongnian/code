    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (canvasCluesPanel.gameObject.activeSelf == false)
            {
                canvasCluesPanel.gameObject.SetActive(true);                
            }
        }
    }
