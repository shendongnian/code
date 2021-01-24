    private Sprite ReturnItemIcon(BaseItem item)
    {
        Sprite icon = null;
        if(item.ItemType == BaseItem.ItemTypes.ELIXIR)
        {
            BaseElixirItem elixiritem = (BaseElixirItem)item;
            if(elixiritem.ElixirType == BaseElixirItem.ElixirTypes.ORDINARY)
            {
                icon = Resources.Load<Sprite>("ItemIcons/ordinaryelixir");
            } 
            else if (elixiritem.ElixirType == BaseElixirItem.ElixirTypes.RARE)
            {
                icon = Resources.Load<Sprite>("ItemIcons/rareelixir");
            } 
            else if (elixiritem.ElixirType == BaseElixirItem.ElixirTypes.LEGENDARY) 
            {
                icon = Resources.Load<Sprite>("ItemIcons/legendaryelixir");
            }
        } 
        else if(item.ItemType == BaseItem.ItemTypes.EQUIPMENT)
        {
            //sprawdzenie typow przedmiotow
        } 
        else if(item.ItemType == BaseItem.ItemTypes.CHEST)
        {
            //i tu tez
        }
        return icon;
    }
