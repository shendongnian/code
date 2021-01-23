    for (int b = 0; b < ItemInventory.Count(); b++) {
         Item i = ItemInventory.Keys.ElementAt(b);
         if (i.GetName().Equals(item) && ItemInventory[i] >= 1) {
             temp = true;
             break;
         }
    }
    return temp;
