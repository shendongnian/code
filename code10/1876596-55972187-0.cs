 c#
List<A> listA = new List<A>();
if (listA != null)
{
    foreach (var temp in listA)
    {
        if (temp.C.Any(c => c.D == 123))
        {
            // todo your logic
        }
    }
}
