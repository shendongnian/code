    public Dictionary<string, ParentObject> GetProgress(int id)
    {
        Dictionary<string, ParentObject> progresses = new Dictionary<string, ParentObject>();
        if (id == 1)
        {
            var o1 = new Object1();
            progresses.Add(id.ToString(), o1);
        }
        else if (id == 2)
        {
            var o2 = new Object2();
            progresses.Add(id.ToString(), o2);
        }
        return progresses;
    }
