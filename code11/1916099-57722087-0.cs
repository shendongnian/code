    public GameObject leftHand;
    public GameObject leftHandOnChest;
    void Start()
    {
        leftHandOnChest.SetActive(false);
        leftHand.SetActive(true);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.compareTag ("CPRStart"))
        {
            leftHandOnChest.SetActive(true);
            leftHand.SetActive(false); 
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.compareTag ("CPRStart"))
        {
            leftHandOnChest.SetActive(false);
            leftHand.SetActive(true);
        }
    }
