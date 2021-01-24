public static class AllAcess
{
    public static SomeType var1;
    static ALlAcess()
    {
        if (somecondition)
        {
            var1 = x;
        }
        else
        {
            var1 = y;
        }
    }
}
This is run at some point before `var1` is accessed for the first time.
Note, **do not** do anything too complicated in a static constructor. Do not do anything which touches the file or network, or does any threading.
