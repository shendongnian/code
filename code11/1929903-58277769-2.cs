    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HubTrigger")
        {
            PlayerPrefsX.SetBool("level01Complete", true);
        }
    }
