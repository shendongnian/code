    public void OnDrop (PointerEventData eventData)
    {
        if(!item)
        {
            DragHandeler.itemBeingDragged.transform.SetParent (transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null,(x,y) => x.HasChanged ());
            
            // This code will check if all slots are full and load new scene if they are
            Slot[] allSlots = FindObjectsOfType<Slot>();
            bool areAllSlotsFull = true;
            foreach (Slot slot in allSlots)
            {
                if (slot.item == null)
                {
                    areAllSlotsFull = false;
                    break;
                }
            }
            if (areAllSlotsFull)
            {
                string nextSceneName = "YourScene"; // Place the name of scene you want to load next
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
            }
        }
    }
