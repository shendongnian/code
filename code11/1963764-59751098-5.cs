    private Sprite ReturnItemIcon(BaseItem item)
    {
        Sprite icon = null;
    
        // then you should better use switch-case blocks
        switch(item.ItemType)
        {
            case BaseItem.ItemTypes.ELIXIR:
                BaseElixirItem elixiritem = (BaseElixirItem)item;
                
                switch(elixiritem.ElixirType)
                {
                    case BaseElixirItem.ElixirTypes.ORDINARY:
                        icon = Resources.Load<Sprite>("ItemIcons/ordinaryelixir");
                        break;
                
                    case BaseElixirItem.ElixirTypes.RARE:
                        icon = Resources.Load<Sprite>("ItemIcons/rareelixir");
                        break;
                
                    case BaseElixirItem.ElixirTypes.LEGENDARY:
                        icon = Resources.Load<Sprite>("ItemIcons/legendaryelixir");
                        break;
    
                    default:
                        throw new ArgumentOutOfRangeException(nameof(elixiritem.ElixirType), elixiritem.ElixirType, null);
                }
                break;
    
            case BaseItem.ItemTypes.EQUIPMENT:
                //sprawdzenie typow przedmiotow
                break;
            
            case BaseItem.ItemTypes.CHEST:
                //i tu tez
                break;
    
            default:
                throw new ArgumentOutOfRangeException(nameof(item.ItemType), item.ItemType, null);
        }
    
        return icon;
    }
