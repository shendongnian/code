    IImmutableList<int> current = ImList<int>.Empty;
    IImmutableList<IImmutableList<int>> undo = ImList<ImmutableList<int>>.Empty
    IImmutableList<IImmutableList<int>> redo = ImList<ImmutableList<int>>.Empty;
    public void Add(int newItem)
    {
        var newCurrent = current.Append(newItem);
        undo = undo.Append(current);
        redo = ImList<ImmutableList<int>>.Empty;
        current = newCurrent;
    }
    public void Undo()
    {
        var newCurrent = undo.LastItem;
        undo = undo.RemoveLast();
        redo = redo.Append(current);
        current = newCurrent;
    }
    public void Redo()
    {
        var newCurrent = redo.LastItem;
        undo = undo.Append(current);
        redo = redo.RemoveLast();
        current = newCurrent;
    }
        
