 c#
public bool ArrangeCardOrder(bool IsFirstToLast)
{
    void DoTheThing()
    {
        if (IsFirstToLast)
            cIndex = cIndex == cIndexLast ? 0 : cIndex++;
        else
            cIndex = cIndex == 0 ? cIndexLast : cIndex--;
    }
    try
    {
        if (/* snip for brevity*/)
        {
            DoTheThing();
            return true;
        }
        while (true)
        {
            DoTheThing();
            // ...
