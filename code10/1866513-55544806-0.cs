// workers is an IList<>.
public object TryDoStuff()
{
    for (int i = 0; i < workers.Count; i++)
    {
        try
        {
            return worker[i].DoStuff();
        }
        catch
        {
            if (i == workers.Count - 1)
            {
                throw; // This preserves the stack trace
            }
            else
            {
                // XXX If workers is changed by another thread here. XXX
                continue; // Try the next worker
            }
        }
    }
}
