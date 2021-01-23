    public static IEnumerable<XElement> Parents(this XObject obj)
    {
        XElement e = obj.Parent;
        while (e != null)
        {
            yield return e;
            e = e.Parent;
        }
    }
