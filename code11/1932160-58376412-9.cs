    list.GroupBy(x => x, new ElementComparer()).Select(g =>
    {
        // Here you need to either clone the first element of the group like
        // @jdweng did, or create a new instance of Element like I'm doing below
        Element element = new Element();
        foreach (var prop in element.GetType().GetProperties())
        {
            if (prop.Name == "price")
            {
                prop.SetValue(element, g.Sum(y => y.price));
            }
            else
            {
                prop.SetValue(element, prop.GetValue(g.First()));
            }                   
        }
        return element;
    });
