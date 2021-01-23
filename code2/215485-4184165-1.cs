    public bool MoveNext()
    {
        this.tree.VersionCheck();
        if (this.version != this.tree.version)
        {
            ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
        }
        if (this.stack.Count == 0)
        {
            this.current = null;
            return false;
        }
        this.current = this.stack.Pop();
        SortedSet<T>.Node item = this.reverse ? this.current.Left : this.current.Right;
        SortedSet<T>.Node node2 = null;
        SortedSet<T>.Node node3 = null;
        while (item != null)
        {
            node2 = this.reverse ? item.Right : item.Left;
            node3 = this.reverse ? item.Left : item.Right;
            if (this.tree.IsWithinRange(item.Item))
            {
                this.stack.Push(item);
                item = node2;
            }
            else
            {
                if ((node3 == null) || !this.tree.IsWithinRange(node3.Item))
                {
                    item = node2;
                    continue;
                }
                item = node3;
            }
        }
        return true;
    }
 
