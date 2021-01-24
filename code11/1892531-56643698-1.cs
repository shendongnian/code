    public void UpdateUI()
    {
        // first clean up previously instantiated stuff
        while(contentPanel.transform.childcount != 0)
        {
            Destroy(contentPanel.transform.GetChild(0));
        }
    
        // also reset the according list
        itemSlots.Clear();
    
        foreach (var inventoryItem in playerInventory.InventoryList)
        {          
            if (inventoryItem != null)
            {
                Debug.Log("Creating new inventory slot...");
                var newSlot = Instantiate(itemSlot, contentPanel.transform).GetComponent<ItemSlot>();
                newSlot.AddItem(inventoryItem);
                itemSlots.Add(newSlot.gameObject);
            }
        }
    }
