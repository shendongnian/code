    using System.Linq;
    ...
    public void purchaseItem()
    {
        var selectedItem = item.FirstOrDefault(i => i.itemSelected);
    
        // Nothing was selected => do nothing
        if(!selectedItem) return;
    
        // subtract price of the item from the balance
        pointsManager.gameCash -= selectedItem.itemPrice;
        ...
    }
