    ….monobehavior:
    public GameObject object;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            {
               object.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        object.SetActive(false);
    }
    ...
