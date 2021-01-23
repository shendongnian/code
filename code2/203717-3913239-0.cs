    public int Compare(Person p1, Person p2)
    {
        int primary = p1.Name.CompareTo(p2.Name);
        if (primary != 0)
        {
            return primary;
        }
        // Note reverse order of comparison to get descending
        return p2.Age.CompareTo(p1.Age);
    }
