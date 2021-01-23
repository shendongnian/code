    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public bool Remove(T item)
    {
        int index = this.IndexOf(item);
        if (index >= 0)
        {
            this.RemoveAt(index);
            return true;
        }
        return false;
    }
 
