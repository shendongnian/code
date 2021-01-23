    public IEnumerator GetEnumerator() { 
        if (owner.VirtualMode) { 
            throw new InvalidOperationException(SR.GetString(SR.ListViewCantAccessSelectedItemsCollectionWhenInVirtualMode));
        } 
        ListViewItem[] items = SelectedItemArray;
        if (items != null) {
            return items.GetEnumerator(); 
        }
        else { 
            return new ListViewItem[0].GetEnumerator(); 
        }
    } 
