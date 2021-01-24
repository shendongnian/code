    public void OnDrop (PointerEventData eventData)
    {
        if(!item)
        {
            DragHandeler.itemBeingDragged.transform.SetParent (transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null,(x,y) => x.HasChanged ());
            
            // This code will check if all slots are full and load new scene if they are
            // If you already have an array/list of all your slots, you can replace this "FindObjectsOfType" with it
            Slot[] allSlots = FindObjectsOfType<Slot>();
            bool areAllBackpackSlotsFull = true;
            foreach (Slot slot in allSlots)
            {
                if (slot.isBackpack == true && slot.item == null)
                {
                    areAllBackpackSlotsFull = false;
                    break;
                }
            }
            if (areAllBackpackSlotsFull)
            {
                string nextSceneName = "YourScene"; // Place the name of scene you want to load next
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
            }
        }
    }
