    private void UpdateItemSlots()
    {
        for (var i = 0; i < ItemSlots.Count / 5 * unlockSlot; i++)
        {
            // Before adding callbacks remove them
            // this is valid even if they were not added before
            // but makes sure they are added only exactly once
            ItemSlots[i].OnPointerEnterEvent -= OnPointerEnterEvent;
            ItemSlots[i].OnPointerExitEvent -= OnPointerExitEvent;
            ItemSlots[i].OnRightClickEvent -= OnRightClickEvent;
            ItemSlots[i].OnBeginDragEvent -= OnBeginDragEvent;
            ItemSlots[i].OnEndDragEvent -= OnEndDragEvent;
            ItemSlots[i].OnDragEvent -= OnDragEvent;
            ItemSlots[i].OnDropEvent -= OnDropEvent;
            // add your callback events .. no need for this complex lambda construct
            ItemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            ItemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            ItemSlots[i].OnRightClickEvent += OnRightClickEvent;
            ItemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            ItemSlots[i].OnEndDragEvent += OnEndDragEvent;
            ItemSlots[i].OnDragEvent += OnDragEvent;
            ItemSlots[i].OnDropEvent += OnDropEvent;
        }
    }
    
