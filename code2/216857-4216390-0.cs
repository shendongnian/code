    list.Where(delegate(item, index) { return index < list.Count - 1 && list[index + 1] == item; });
    // and if we assign the delegate to a local variable:
    var anonymousDelegate = delegate(item, index)
        {
            return index < list.Count - 1 && list[index + 1] == item;
        }
    list.Where(anonymousDelegate);
