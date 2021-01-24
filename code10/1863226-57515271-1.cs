private void Shift_Schedule_UP_Recursive(ItemWithPredPostcessor dr)
{
    try
    {
        DoRealShift(dr);
    }
    catch 
    {
        // Assume relavant error handling at this level in the stack.  This probably isn't important to maintain, but it'd be interested if we could.
        throw;  
    }
}
private void DoRealShift(ItemWithPredPostcessor dr)
{
    var state = new Stack<IEnumerator<ItemWithPredPostcessor>>();
    state.Push(GetPostcessorsEnumerator(dr));
    while (state.Count > 0)
    {
        InitializeVariablesForShift();
    
        while (state.Peek().MoveNext())
        {
            ItemWithPredPostcessor drPost = state.Peek().Current;
            ItemWithPredPostcessor drPostDetails = drPost.Predecessor;
            bool needsShift = StartShift(drPostDetails);
            if (needsShift)
            {
                ShiftEverything(drPostDetails);
                // Shift all children first, prior to returning to shift the current set.
                state.Push(GetPostcessorsEnumerator(drPostDetails));
            }
        }
        state.Pop(); // Remove current from list, as we've completed.
    }
}
