    private static Control FindNestedControl(string id, Control parent)
    {
        Control item = parent.FindControl(id);
    
        if(item == null) 
        {
            foreach(var child in parent.Controls)
            {
                item = child.FindNestedControl(id, child);
    
                if(item != null)
                {
                    return item;
                }
            }
        }
    
        return null;
    }
