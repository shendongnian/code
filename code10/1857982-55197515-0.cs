    //the inventory event handler
    inventory.OnRightClickEvent += Equip;
    inventory.OnBeginDragEvent += BeginDrag;
    inventory.OnEndDragEvent += EndDrag;
    inventory.OnDragEvent += Drag;
    inventory.OnDropEvent += Drop;
    //the itemslot event handler
    for(int i=0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }
