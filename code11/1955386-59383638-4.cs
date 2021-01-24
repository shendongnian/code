public static class ListExt
{
    public static void RemoveNulls<T>(this List<T> list)
        where T : new()
    {
        list.RemoveAll(t => t == null);
    }
}
It doesn't use any additional memory and it mutates `list` instance only, from what I see in the question and the comments this is what you are trying to achieve.
Later you can use it as you want
foundNeighbors.RemoveNulls();
and like I said this will change `foundNeighbors` directly.
@Edit: like others noticed if you want it to be faster (O(N)) you should use `RemoveAll` instead.
