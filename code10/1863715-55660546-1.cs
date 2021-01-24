    ….monobehavior:
    public GameObject object;
    void Start()
    {
        object.SetActive(false);
        object2.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
               object.SetActive(true);
               object2.SetActive(false);
            }
        }
    }
    /// void OnTriggerStay and 'object2' are extras (for if u want a keycode to show an additional text)
    void OnTriggerStay(Collider other)
    {
        if (object.activeInHierarchy && Input.GetKeyUp(KeyCode.E))
        {
            object.SetActive(false);
            object2.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        object.SetActive(false);
        object2.SetActive(false);
    }
    ...
