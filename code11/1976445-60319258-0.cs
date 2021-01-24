private List<string> lst;
private void MethodA_GetAll()
{
    if (lst == null)
    {
        lock (_locker)
        {
            if (lst == null)
            {
                // do your thing
            }
        }
    }
}
