    if (ordering.Count != 0)
    {
        people = people.OrderBy(ordering[0]);
        for (int i = 1; i < ordering.Count; i++)
        {
            people = people.ThenBy(ordering[i]);
        }
    }
