    public GameObject itemButtonPrefab; // drag your Prefab to this field in the inspector
    public Button itemButton;  // the "real" instance of your prefab in the scene
    
    void AddListeners()    
    {
        itemButton.onClick.AddListener(() => GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GainHealth(50));
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    itemButton = Instantiate(itemButtonPrefab, inventory.slots[i].transform, false).GetComponent<Button>();
                    AddListeners ();
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
