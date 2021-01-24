    public void UpdateUI()
    {
        // first clean up previously instantiated stuff
        while(contentPanel.transform.childcount != 0)
        {
            Destroy(contentPanel.transform.GetChild(0));
        }
    
        // also reset the according list
        itemSlots.Clear();
    
        for (int i = 0; i < playerInventory.InventoryList.Count; i++)
        {          
            if (playerInventory.InventoryList[i] != null)
            {
                Debug.Log("Creating new inventory slot...");
                var newSlot = Instantiate(itemSlot, contentPanel.transform).GetComponent<ItemSlot>();
                newSlot.AddItem(playerInventory.InventoryList[i]);
                itemSlots.Add(newSlot.gameObject);
            }
        }
    }
