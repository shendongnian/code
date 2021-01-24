public static class ListExt
{
    public static void RemoveNulls<T>(this List<T> list)
        where T : new()
    {
        for(int i = 0; i < list.Count; ++i)
        {
            if(list[i] == null)
                list.RemoveAt(i);
        }
    }
}
I know it looks a bit sketchy, but it does use any additional memory, therefore, changing the `list` instance only, from what I see in the answer and the comments this is what you are trying to achieve.
Later you can use it like you wanted
foundNeighbors.RemoveNulls();
and like I said this will change `foundNeighbors` directly.
