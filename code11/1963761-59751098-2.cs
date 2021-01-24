    private Sprite ReturnItemIcon(BaseItem item)
    {
        switch(item.ItemType)
        {
            case BaseItem.ItemTypes.ELIXIR:
                BaseElixirItem elixiritem = (BaseElixirItem)item;
                
                switch(elixiritem.ElixirType)
                {
                    case BaseElixirItem.ElixirTypes.ORDINARY:
                        return Resources.Load<Sprite>("ItemIcons/ordinaryelixir");
                
                    case BaseElixirItem.ElixirTypes.RARE:
                        return Resources.Load<Sprite>("ItemIcons/rareelixir");
                
                    case BaseElixirItem.ElixirTypes.LEGENDARY:
                        return Resources.Load<Sprite>("ItemIcons/legendaryelixir");
    
                    default:
                        throw new ArgumentOutOfRangeException(nameof(elixiritem.ElixirType), elixiritem.ElixirType, null);
                }
    
            case BaseItem.ItemTypes.EQUIPMENT:
                //sprawdzenie typow przedmiotow
                break;
            
            case BaseItem.ItemTypes.CHEST:
                //i tu tez
                break;
    
            default:
                throw new ArgumentOutOfRangeException(nameof(item.ItemType), item.ItemType, null);
        }
